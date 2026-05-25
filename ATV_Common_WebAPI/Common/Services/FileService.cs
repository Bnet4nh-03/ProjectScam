using Microsoft.Extensions.Options;
using ATV_Common_WebAPI.Common.Interfaces;
using ATV_Common_WebAPI.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ATV_Common_WebAPI.Common.Services
{
    /// <summary>
    /// Implements the core logic for file operations, including security checks and path management.
    /// </summary>
    public class FileService : IFileService
    {
        private FileServiceSettings _settings;
        private string _directoryStartWith => _settings.DirectoryStartWith;
        private Dictionary<string, string> _appDirectoryMappings => _settings.AppDirectoryMappings;
        private readonly Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider _contentTypeProvider;

        // Injects configuration settings and a service to determine file MIME types.
        // IOptionsMonitor allows the service to react to configuration changes without restarting.
        public FileService(IOptionsMonitor<FileServiceSettings> monitor, Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider contentTypeProvider)
        {
            // Store the initial settings.
            _settings = monitor.CurrentValue;
            _contentTypeProvider = contentTypeProvider;
            // Subscribe to configuration changes to keep the settings up-to-date.
            monitor.OnChange((settings, name) => {
                _settings = settings;
            });
        }

        /// <summary>
        /// Retrieves a file for downloading.
        /// </summary>
        /// <param name="filePath">The client-provided path to the file.</param>
        /// <returns>A tuple containing the file stream, its content type, and the filename.</returns>
        public async Task<(Stream stream, string contentType, string fileDownloadName)> GetFileAsync(string filePath, string fileName)
        {
            // 1. Security: Resolve the client-provided path against a secure base directory to prevent directory traversal attacks.
            var fullPath = ResolveAndValidatePath(filePath, _directoryStartWith);

            // 2. Check if the file actually exists at the resolved path.
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("File not found.", fullPath);
            }

            // 3. Determine the MIME type of the file based on its extension (e.g., ".pdf" -> "application/pdf").
            if (!_contentTypeProvider.TryGetContentType(fullPath, out var contentType))
            {
                // Fallback to a generic binary stream type if the extension is unknown.
                contentType = "application/octet-stream";
            }

            // 4. Open a read-only, asynchronous stream to the file.
            var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
            var fileDownloadName = fileName != "" ? fileName : Path.GetFileName(fullPath);

            // 5. Return the stream and metadata.
            return await Task.FromResult((stream, contentType, fileDownloadName));
        }

        /// <summary>
        /// Saves an uploaded file stream to disk.
        /// </summary>
        /// <param name="setFileInfo">Metadata about the file and how to save it.</param>
        /// <param name="fileStream">The incoming raw file stream.</param>
        /// <param name="fileName">The original filename from the multipart header.</param>
        /// <returns>An object containing the full and relative paths of the saved file.</returns>
        public async Task<object> SaveFileAsync(SetFileInfo setFileInfo, Stream fileStream, string fileName)
        {
            // 1. Validate required arguments.
            if (setFileInfo == null) throw new ArgumentNullException(nameof(setFileInfo));
            if (fileStream == null) throw new ArgumentNullException(nameof(fileStream));
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

            // 2. Determine the secure base directory for the upload based on AppName or a specified Destination.
            var baseDir = GetValidatedDestinationDirectory(setFileInfo);

            string fullPath;
            string relativePath;

            // 3. Determine the final path and filename based on the requested SaveMode.
            switch (setFileInfo.SaveMode?.Trim())
            {
                // "Rename" mode: Creates a unique, non-colliding filename and stores it in a date-based subdirectory.
                case var mode when mode.Equals("Rename", StringComparison.OrdinalIgnoreCase):
                {
                    var now = DateTime.Now;
                    // Create a subdirectory structure like "YYYY/MM/DD".
                    var datePath = Path.Combine(now.Year.ToString("D4"), now.Month.ToString("D2"), now.Day.ToString("D2"));
                    var destinationDir = Path.Combine(baseDir, datePath);
                    Directory.CreateDirectory(destinationDir);

                    // Sanitize the original filename to remove invalid characters.
                    var originalFileName = SanitizeFileName(setFileInfo.FileName ?? fileName);
                    // Create a unique filename to prevent overwrites and provide a traceable identifier.
                    var timestamp = now.ToString("yyyyMMdd'T'HHmmss");
                    var uuidPart = Guid.NewGuid().ToString("N");
                    var newFileName = $"{timestamp}_{uuidPart}_{originalFileName}";

                    fullPath = Path.Combine(destinationDir, newFileName);
                    relativePath = Path.Combine(datePath, newFileName);
                    break;
                }

                // "KeepName" mode: Uses the original filename. This can lead to overwrites if not managed carefully.
                case var mode when mode.Equals("KeepName", StringComparison.OrdinalIgnoreCase):
                {
                    Directory.CreateDirectory(baseDir);
                    var originalFileName = SanitizeFileName(setFileInfo.FileName ?? fileName);
                    fullPath = Path.Combine(baseDir, originalFileName);
                    relativePath = originalFileName;
                    break;
                }

                default:
                    throw new ArgumentException($"Invalid SaveMode: {setFileInfo.SaveMode}");
            }

            // 4. Use a temporary file to ensure atomic writes. The file is first written to a ".tmp" file.
            var tempFileName = $"{Path.GetFileName(fullPath)}.{DateTimeOffset.Now.ToUnixTimeMilliseconds()}_{Guid.NewGuid():N}.tmp";
            var tempPath = Path.Combine(Path.GetDirectoryName(fullPath)!, tempFileName);

            try
            {
                // 5. Stream the uploaded content into the temporary file.
                await using (var tempStream = new FileStream(tempPath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                {
                    await fileStream.CopyToAsync(tempStream);
                    await tempStream.FlushAsync(); // Ensure all data is written to disk.
                }

                // 6. Security: Verify that the size of the received file matches the size declared by the client.
                var tempInfo = new FileInfo(tempPath);
                if (setFileInfo.FileSize > 0 && tempInfo.Length != setFileInfo.FileSize)
                {
                    throw new System.Security.SecurityException($"File size mismatch. Client claimed {setFileInfo.FileSize} bytes, but temp file has {tempInfo.Length} bytes.");
                }

                // 7. If all checks pass, move (rename) the temporary file to its final destination. This is an atomic operation on most filesystems.
                File.Move(tempPath, fullPath, overwrite: true);
            }
            catch
            {
                // 8. Cleanup: If any error occurs, delete the temporary file to avoid leaving orphaned files.
                if (File.Exists(tempPath)) File.Delete(tempPath);
                throw; // Re-throw the original exception.
            }

            // 9. Return the paths of the newly saved file.
            return new
            {
                FullFilePath = fullPath,
                RelativePath = GetRelativePath(fullPath, baseDir)
            };
        }

        /// <summary>
        /// Acts as a dispatcher for various file system operations based on the request command.
        /// </summary>
        public Task<object> PerformFileOperationAsync(FileOperationRequest request)
        {
            // 1. Perform validation on the incoming request.
            ValidateRequest(request);

            // 2. Dispatch to the appropriate private method based on the command string.
            switch (request.Command.ToLowerInvariant())
            {
                case "move":
                    return MoveAsync(request.Operation as MoveOperationDetails);
                case "copy":
                    return CopyAsync(request.Operation as CopyOperationDetails);
                case "delete":
                    return DeleteAsync(request.Operation as DeleteOperationDetails);
                case "list":
                    return ListAsync(request.Operation as ListOperationDetails);
                case "rename":
                    return RenameAsync(request.Operation as RenameOperationDetails);
                case "createdirectory":
                    return CreateDirectoryAsync(request.Operation as CreateDirectoryOperationDetails);
                default:
                    throw new ArgumentException("Invalid command.");
            }
        }

        /// <summary>
        /// Validates the file operation request.
        /// </summary>
        private void ValidateRequest(FileOperationRequest request)
        {
            // 1. Check for null or empty required properties on the base request.
            if (request == null) throw new ArgumentNullException(nameof(request), "Request is null.");
            if (string.IsNullOrEmpty(request.Command)) throw new ArgumentException("Command is required.", nameof(request.Command));
            if (request.Operation == null) throw new ArgumentException("Operation details are required.", nameof(request.Operation));
            if (string.IsNullOrEmpty(request.Operation.SourcePath)) throw new ArgumentException("SourcePath is required.", nameof(request.Operation.SourcePath));

            // 2. Perform validation specific to each command type.
            switch (request.Command.ToLowerInvariant())
            {
                case "move" when request.Operation is not MoveOperationDetails op || string.IsNullOrEmpty(op.DestinationPath):
                    throw new ArgumentException("Invalid operation details or missing DestinationPath for move command.");
                case "copy" when request.Operation is not CopyOperationDetails op || string.IsNullOrEmpty(op.DestinationPath):
                    throw new ArgumentException("Invalid operation details or missing DestinationPath for copy command.");
                case "delete" when request.Operation is not DeleteOperationDetails:
                    throw new ArgumentException("Invalid operation details for delete command.");
                case "list" when request.Operation is not ListOperationDetails op || (op.Paginate && (op.PageNumber <= 0 || op.PageSize <= 0)):
                    throw new ArgumentException("Invalid operation details or invalid pagination parameters for list command.");
                case "rename" when request.Operation is not RenameOperationDetails op || string.IsNullOrEmpty(op.NewName):
                    throw new ArgumentException("Invalid operation details or missing NewName for rename command.");
                case "createdirectory" when request.Operation is not CreateDirectoryOperationDetails:
                    throw new ArgumentException("Invalid operation details for create directory command.");
            }
        }

        /// <summary>
        /// Moves a file or directory.
        /// </summary>
        private async Task<object> MoveAsync(MoveOperationDetails operation)
        {
            // 1. Security: Resolve and validate both source and destination paths.
            var sourcePath = ResolveAndValidatePath(operation.SourcePath, _directoryStartWith);
            var destinationPath = ResolveAndValidatePath(operation.DestinationPath, _directoryStartWith);

            // 2. Execute the move operation on a background thread to avoid blocking.
            await Task.Run(() =>
            {
                if (File.Exists(sourcePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
                    File.Move(sourcePath, destinationPath, true); // `true` allows overwriting the destination.
                }
                else if (Directory.Exists(sourcePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
                    Directory.Move(sourcePath, destinationPath);
                }
                else
                {
                    throw new FileNotFoundException($"File or directory not found: {sourcePath}");
                }
            });

            return new { Success = true, Message = "Move operation completed successfully." };
        }

        /// <summary>
        /// Copies a file or directory.
        /// </summary>
        private async Task<object> CopyAsync(CopyOperationDetails operation)
        {
            // 1. Security: Resolve and validate both source and destination paths.
            var sourcePath = ResolveAndValidatePath(operation.SourcePath, _directoryStartWith);
            var destinationPath = ResolveAndValidatePath(operation.DestinationPath, _directoryStartWith);

            // 2. Check if the source is a file or a directory and call the appropriate copy helper.
            if (File.Exists(sourcePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)!);
                await CopyFileAsync(sourcePath, destinationPath);
            }
            else if (Directory.Exists(sourcePath))
            {
                await CopyDirectoryAsync(sourcePath, destinationPath); // This is a recursive copy.
            }
            else
            {
                throw new FileNotFoundException($"File or directory not found: {sourcePath}");
            }

            return new { Success = true, Message = "Copy operation completed successfully." };
        }

        /// <summary>
        /// Deletes a file or directory.
        /// </summary>
        private async Task<object> DeleteAsync(DeleteOperationDetails operation)
        {
            // 1. Security: Resolve and validate the source path.
            var sourcePath = ResolveAndValidatePath(operation.SourcePath, _directoryStartWith);
            
            // 2. Execute the delete on a background thread.
            await Task.Run(() =>
            {
                if (File.Exists(sourcePath))
                {
                    File.Delete(sourcePath);
                }
                else if (Directory.Exists(sourcePath))
                {
                    // The 'Recursive' flag must be true to delete a non-empty directory.
                    Directory.Delete(sourcePath, operation.Recursive);
                }
                else
                {
                    throw new FileNotFoundException($"File or directory not found: {sourcePath}");
                }
            });
            return new { Success = true, Message = "Delete operation completed successfully." };
        }

        /// <summary>
        /// Lists files and directories at a given path.
        /// </summary>
        private async Task<object> ListAsync(ListOperationDetails operation)
        {
            // 1. Security: Resolve and validate the path.
            var fullPath = ResolveAndValidatePath(operation.SourcePath, _directoryStartWith);
            if (!Directory.Exists(fullPath))
            {
                throw new DirectoryNotFoundException($"Directory not found: {fullPath}");
            }

            // 2. Execute the listing on a background thread.
            return await Task.Run(() =>
            {
                var searchPattern = string.IsNullOrEmpty(operation.FilePattern) ? "*" : operation.FilePattern;
                var dirInfo = new DirectoryInfo(fullPath);

                // 3. Get all directories and files matching the pattern and project them into a common model.
                var items = dirInfo.GetDirectories(searchPattern).Select(d => new FileListItem { Name = d.Name, Type = "Directory", LastModified = d.LastWriteTime, Size = null })
                    .Concat(dirInfo.GetFiles(searchPattern).Select(f => new FileListItem { Name = f.Name, Size = f.Length, Type = "File", LastModified = f.LastWriteTime }))
                    .ToList();

                // 4. Sort the combined list based on the requested criteria.
                var sortedItems = SortItems(items, operation.OrderBy, operation.Ascending);

                // 5. If pagination is enabled, take only the items for the current page.
                if (operation.Paginate)
                {
                    var paginatedItems = sortedItems.Skip((operation.PageNumber - 1) * operation.PageSize).Take(operation.PageSize).ToList();
                    return (object)new { Items = paginatedItems, TotalCount = sortedItems.Count };
                }
                
                // 6. If not paginating, return all items.
                return (object)new { Items = sortedItems, TotalCount = sortedItems.Count };
            });
        }

        /// <summary>
        /// Renames a file or directory.
        /// </summary>
        private async Task<object> RenameAsync(RenameOperationDetails operation)
        {
            // 1. Security: Resolve and validate the source path.
            var sourcePath = ResolveAndValidatePath(operation.SourcePath, _directoryStartWith);
            // 2. Sanitize the new name to prevent invalid characters.
            var newName = SanitizeFileName(operation.NewName);
            var destinationPath = Path.Combine(Path.GetDirectoryName(sourcePath)!, newName);

            // Note: The destination path for a rename is inherently safe from traversal attacks
            // because it's in the same directory as the validated source path.

            // 3. Execute the rename (move) on a background thread.
            await Task.Run(() =>
            {
                if (File.Exists(sourcePath))
                {
                    File.Move(sourcePath, destinationPath);
                }
                else if (Directory.Exists(sourcePath))
                {
                    Directory.Move(sourcePath, destinationPath);
                }
                else
                {
                    throw new FileNotFoundException($"File or directory not found: {sourcePath}");
                }
            });

            return new { Success = true, Message = "Rename operation completed successfully." };
        }

        /// <summary>
        /// Creates a new directory.
        /// </summary>
        private async Task<object> CreateDirectoryAsync(CreateDirectoryOperationDetails operation)
        {
            // 1. Security: Resolve and validate the path for the new directory.
            var fullPath = ResolveAndValidatePath(operation.SourcePath, _directoryStartWith);

            // 2. Execute the creation on a background thread.
            await Task.Run(() =>
            {
                if (Directory.Exists(fullPath))
                {
                    throw new IOException($"Directory already exists: {fullPath}");
                }
                Directory.CreateDirectory(fullPath);
            });

            return new { Success = true, Message = "Create directory operation completed successfully." };
        }

        /// <summary>
        /// Helper method to sort a list of file system items.
        /// </summary>
        private List<FileListItem> SortItems(List<FileListItem> items, string orderBy, bool ascending)
        {
            var sorted = orderBy.ToLowerInvariant() switch
            {
                "name" => ascending ? items.OrderBy(i => i.Name) : items.OrderByDescending(i => i.Name),
                "type" => ascending ? items.OrderBy(i => i.Type) : items.OrderByDescending(i => i.Type),
                "lastmodified" => ascending ? items.OrderBy(i => i.LastModified) : items.OrderByDescending(i => i.LastModified),
                "size" => ascending ? items.OrderBy(i => i.Size ?? -1) : items.OrderByDescending(i => i.Size ?? -1), // Treat null size (directories) as -1 for sorting.
                _ => throw new ArgumentException("Invalid orderBy parameter. Supported values are 'name', 'type', 'lastmodified', and 'size'.")
            };
            return sorted.ToList();
        }

        /// <summary>
        /// Security-critical method to resolve a relative path against a base directory and prevent directory traversal attacks.
        /// </summary>
        /// <param name="relativePath">The path provided by the client.</param>
        /// <param name="baseDirectory">The secure root directory this path must be within.</param>
        /// <returns>A safe, absolute file system path.</returns>
        private string ResolveAndValidatePath(string relativePath, string baseDirectory)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) throw new ArgumentException("Path cannot be null or empty.", nameof(relativePath));
            if (string.IsNullOrWhiteSpace(baseDirectory)) throw new ArgumentException("Base directory cannot be configured.", nameof(baseDirectory));

            // 1. Get the absolute path of the secure base directory.
            var fullBaseDirectory = Path.GetFullPath(baseDirectory);
            // 2. Combine it with the relative path from the client.
            var combinedPath = Path.Combine(fullBaseDirectory, relativePath);
            // 3. Canonicalize the combined path to resolve any ".." or "." segments.
            var fullPath = Path.GetFullPath(combinedPath);

            // 4. The crucial security check: ensure the final, canonical path still starts with the secure base directory path.
            if (!fullPath.StartsWith(fullBaseDirectory, StringComparison.OrdinalIgnoreCase))
            {
                // If it doesn't, it means the client used ".." or other means to try to access a file outside the allowed folder.
                throw new System.Security.SecurityException("Access to the path is denied. Path is outside the allowed directory.");
            }

            return fullPath;
        }

        /// <summary>
        /// Determines the correct destination directory for an upload based on configuration.
        /// </summary>
        private string GetValidatedDestinationDirectory(SetFileInfo setFileInfo)
        {
            string destination;
            // 1. Prioritize using a pre-configured mapping from the client-provided AppName.
            if (!string.IsNullOrEmpty(setFileInfo.AppName) && _appDirectoryMappings.TryGetValue(setFileInfo.AppName, out var mappedDir))
            {
                destination = mappedDir;
            }
            // 2. If no AppName mapping, use the Destination path provided by the client, but validate it.
            else if (!string.IsNullOrEmpty(setFileInfo.Destination))
            {
                // This path comes from the client, so it MUST be validated to prevent directory traversal.
                return ResolveAndValidatePath(setFileInfo.Destination, _directoryStartWith);
            }
            // 3. If neither is provided, fall back to the "Default" mapping or the root directory.
            else
            {
                destination = _appDirectoryMappings.TryGetValue("Default", out var defaultDir) ? defaultDir : _directoryStartWith;
            }

            // 4. For configured paths (AppName or Default), ensure they are treated as absolute and exist.
            var fullPath = Path.GetFullPath(destination);
            if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
            return fullPath;
        }

        /// <summary>
        /// Removes characters that are invalid in file names.
        /// </summary>
        private string SanitizeFileName(string fileName)
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }

        /// <summary>
        /// Calculates a relative path from a base directory.
        /// </summary>
        private string GetRelativePath(string fullPath, string baseDirectory)
        {
            return Path.GetRelativePath(baseDirectory, fullPath);
        }

        /// <summary>
        /// Helper to copy a single file asynchronously.
        /// </summary>
        private async Task CopyFileAsync(string sourceFile, string destFile)
        {
            await using var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
            await using var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true);
            await sourceStream.CopyToAsync(destStream);
        }

        /// <summary>
        /// Helper to recursively copy a directory and its contents.
        /// </summary>
        private async Task CopyDirectoryAsync(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            // Copy all files in the current directory.
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                await CopyFileAsync(file, Path.Combine(destDir, Path.GetFileName(file)));
            }
            // Recurse into subdirectories.
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                await CopyDirectoryAsync(subDir, Path.Combine(destDir, Path.GetFileName(subDir)));
            }
        }

        /// <summary>
        /// Handles the full lifecycle of an HTTP GET file request.
        /// </summary>
        public async Task HandleGetFileRequestAsync(HttpContext context, GetFileRequest request)
        {
            try
            {
                // 1. Get the file stream and metadata.
                var (stream, contentType, fileDownloadName) = await GetFileAsync(request.FilePath, request.FileName ?? string.Empty);
                
                // 2. Set response headers to prompt a "Save As" dialog in the browser.
                context.Response.Headers.Append("Content-Disposition", $"attachment; filename=\"{fileDownloadName}\"");
                context.Response.ContentType = contentType;
                
                // 3. Copy the file stream directly to the HTTP response body.
                await using (stream) 
                {
                    await stream.CopyToAsync(context.Response.Body);
                }
            }
            // 4. Handle specific exceptions and map them to appropriate HTTP status codes.
            catch (FileNotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch (System.Security.SecurityException ex)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { message = ex.Message, details = ex.ToString() });
            }
        }

        /// <summary>
        /// Handles the full lifecycle of an HTTP SET file (upload) request.
        /// </summary>
        public async Task<object> HandleSetFileRequestAsync(HttpContext context)
        {
            // 1. Ensure the request is a multipart form.
            if (!context.Request.HasFormContentType)
            {
                throw new NotSupportedException("Request is not a multipart form.");
            }

            // 2. Retrieve the decrypted file metadata, which the middleware placed in HttpContext.Items.
            if (!context.Items.TryGetValue("DecryptedSetFileInfo", out var setFileInfoObject) || setFileInfoObject is not string setFileInfoJson)
            {
                throw new ArgumentException("Decrypted file metadata not found in context.");
            }

            // 3. Deserialize the metadata JSON into a SetFileInfo object.
            SetFileInfo setFileInfo;
            try
            {
                setFileInfo = JsonSerializer.Deserialize<SetFileInfo>(setFileInfoJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Invalid metadata format.", ex);
            }

            // 4. Initialize a streaming reader for the multipart request body.
            var boundary = HeaderUtilities.RemoveQuotes(MediaTypeHeaderValue.Parse(context.Request.ContentType).Boundary).Value;
            var reader = new MultipartReader(boundary, context.Request.Body);

            // 5. Read through the sections of the multipart message one by one.
            var section = await reader.ReadNextSectionAsync();
            while (section != null)
            {
                // 6. Find the section that represents the file content (disposition type is "file" and name is "file").
                if (ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out var contentDisposition) && contentDisposition.IsFileDisposition() && contentDisposition.Name.Value == "file")
                {
                    var fileName = contentDisposition.FileName.Value;
                    // 7. Once found, pass the section's body stream and metadata to the core SaveFileAsync method.
                    return await SaveFileAsync(setFileInfo, section.Body, fileName);
                }
                section = await reader.ReadNextSectionAsync();
            }

            // 8. If no file part was found in the request, throw an error.
            throw new ArgumentException("File part is missing in the multipart request.");
        }
    }
}
