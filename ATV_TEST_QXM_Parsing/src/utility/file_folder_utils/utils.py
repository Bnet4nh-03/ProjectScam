from __future__ import annotations
import os
from pathlib import Path
import ctypes
from typing import List
import gzip
import shutil
import fnmatch
from datetime import datetime, timedelta

def get_files_to_process(directory, pattern):
    """Returns a list of files matching the pattern from the specified directory."""
    return [os.path.join(directory, f) for f in os.listdir(directory) if fnmatch.fnmatch(f, pattern) and os.path.isfile(os.path.join(directory, f))]

def get_files_by_time(directory, pattern, age_minutes):
    """
    Returns a list of files matching the pattern from the specified directory
    that are newer than the specified age in minutes.
    """
    files_to_process = []
    now = datetime.now().replace(second=0, microsecond=0)
    cutoff_time = now - timedelta(minutes=age_minutes)
    cutoff = cutoff_time.timestamp()

    for path in get_files_to_process(directory, pattern):
        mtime = os.path.getmtime(path)
        if mtime >= cutoff:
            files_to_process.append(path)
    return files_to_process

def get_files_for_rename(directory, pattern):
    """
    Returns a list of files matching the pattern from the specified directory,
    excluding files that have already been processed.
    """
    files_to_process = []
    for path in get_files_to_process(directory, pattern):
        if not path.endswith(('_done', '_failed')):
            files_to_process.append(path)
    return files_to_process

def rename_processed_file(file_path, status, logger):
    """Renames a file by appending '_done' or '_failed' based on the status."""
    if status == 'Success':
        new_path = f"{file_path}_done"
        logger.info(f"Renaming processed file to {new_path}")
        os.rename(file_path, new_path)
    else:
        new_path = f"{file_path}_failed"
        logger.error(f"Renaming failed file to {new_path}")
        os.rename(file_path, new_path)

def gzip_file(file_path, output_dir=None):
    """Gzips a file and returns the path to the gzipped file."""
    if output_dir and not os.path.exists(output_dir):
        os.makedirs(output_dir)
    
    gzipped_file_name = f"{os.path.basename(file_path)}.gz"
    if output_dir:
        gzipped_file_path = os.path.join(output_dir, gzipped_file_name)
    else:
        gzipped_file_path = f"{file_path}.gz"

    with open(file_path, 'rb') as f_in:
        with gzip.open(gzipped_file_path, 'wb') as f_out:
            shutil.copyfileobj(f_in, f_out)
    return gzipped_file_path


def _is_hidden(p: Path) -> bool:
    """Return True if path is hidden (dotfiles on POSIX, hidden/system attr on Windows)."""
    if p.name.startswith('.'):
        return True
    if os.name == 'nt':
        FILE_ATTRIBUTE_HIDDEN = 0x2
        FILE_ATTRIBUTE_SYSTEM = 0x4
        attrs = ctypes.windll.kernel32.GetFileAttributesW(str(p))
        if attrs == -1:  # invalid path; treat as not hidden
            return False
        return bool(attrs & (FILE_ATTRIBUTE_HIDDEN | FILE_ATTRIBUTE_SYSTEM))
    return False


def list_folders(
    path: str | Path,
    *,
    recursive: bool = False,
    include_hidden: bool = True,
    follow_symlinks: bool = False,
) -> List[Path]:
    """
    List folders inside `path`.

    Parameters:
        - path: directory to scan
        - recursive: if True, returns all subfolders recursively
        - include_hidden: include hidden folders (dotfiles; Windows hidden/system attrs)
        - follow_symlinks: follow directory symlinks (only affects non-recursive with scandir, and recursion via os.walk)

    Returns:
        - A list of Path objects for each directory found.
    """
    root = Path(path).expanduser().resolve()
    if not root.exists():
        raise FileNotFoundError(f"Path not found: {root}")
    if not root.is_dir():
        raise NotADirectoryError(f"Not a directory: {root}")

    results: List[Path] = []

    if recursive:
        # Control recursion and symlink following with os.walk
        for current_root, dirs, _files in os.walk(root, topdown=True, followlinks=follow_symlinks):
            current_root_path = Path(current_root)

            # Optionally avoid descending into hidden dirs
            if not include_hidden:
                dirs[:] = [d for d in dirs if not _is_hidden(current_root_path / d)]

            for d in dirs:
                candidate = current_root_path / d
                if include_hidden or not _is_hidden(candidate):
                    results.append(candidate)
    else:
        # Single-level scan, fast and symlink-aware
        with os.scandir(root) as it:
            for entry in it:
                try:
                    if entry.is_dir(follow_symlinks=follow_symlinks):
                        p = Path(entry.path)
                        if include_hidden or not _is_hidden(p):
                            results.append(p)
                except PermissionError:
                    # Skip entries we can't access
                    continue

    # Stable, case-insensitive sort by string path
    results.sort(key=lambda p: str(p).lower())
    return results

def find_files_with_patterns(folder: str, patterns: List[str], recursive: bool = False) -> List[Path]:
    """
    Search for files in a folder matching ANY of the given patterns.

    Args:
        folder: Directory to search in.
        patterns: List of glob patterns, e.g. ["*.txt", "*.csv"].
        recursive: True to search subfolders.

    Returns:
        A list of matching Path objects.
    """
    folder_path = Path(folder).expanduser().resolve()
    if not folder_path.is_dir():
        raise NotADirectoryError(f"{folder} is not a valid directory.")

    results = []
    for pat in patterns:
        if recursive:
            results.extend(p for p in folder_path.rglob(pat) if p.is_file())
        else:
            results.extend(p for p in folder_path.glob(pat) if p.is_file())

    # Remove duplicates & sort
    return sorted(set(results))



if __name__ == "__main__":
    # Examples:
    for d in list_folders("\\\\v1cifsn1\\v1tstmachdata$\\TECHWING\\AUTO_EXPORT_SOCKET_OFF", recursive=False, include_hidden=False):
        print(find_files_with_patterns(d, ["*.csv","*Contact_Map*"], recursive=False))

    print("--- recursive ---")
    for d in list_folders(".", recursive=True, include_hidden=True, follow_symlinks=False):
        print(d)