## **Updated Prompt for Implementation**
> All of the below endpoints need in `/Common/File_Method`, refer encrypt decrypt from EncryptionCompressionMiddleware.cs, IEncryptionService.cs, EncryptionService.cs
> 
> **1. `/Get`**  
> - **Method**: `POST`  
> - **Request**: JSON `{ "filePath": "..." }`  
> - **Behavior**:  
>   - Please use decrypt for request from client by EncryptCompression because I will make client send request by EncryptCompression.
>   - Streams the file to the client using `FileStream` + `CopyToAsync` in buffered chunks (e.g., 64KB) to avoid loading the whole file into memory.  
>   - Sets correct `Content-Type` and `Content-Disposition` headers for download.  
>   - Handles file-not-found and permission errors with proper HTTP status codes and JSON error responses.  
>   - Restricts downloads to a configured root directory and sanitizes/normalizes paths to prevent directory traversal.  
> 
> **2. `/Set`**  
> - **Method**: `POST`  
> - **Request**: `multipart/form-data` containing:  
>   - **`metadata`** (string, required) — JSON string with file metadata (e.g., `{ "appname": "...", "destination": "...", "filename": "...", "content-type": "...", "filesize": "...", ... }`).  
>   - **`file`** (file stream, required) — The file to upload.  
> - **Behavior**:  
>   - **Validate metadata first**:  
>     - Please use decrypt for `metadata` from client by EncryptCompression because I will make client send `metadata` by EncryptCompression.
>     - Ensure the `metadata` field exists and is valid JSON.  
>     - Reject the request with `400 Bad Request` if metadata is missing or invalid.  
>     - From appname will determine the destination directory from appsetting.json if have no will use destionation from metadata, if still have no -> use default.
>   - Stream the file directly from the multipart section to disk asynchronously in chunks (e.g., 64KB), without buffering the entire file in memory.  
>   - Support small to multi‑GB files.  
>   - Restrict uploads to a configured root directory and validate file names.  
>   - Configure `FormOptions` and `RequestSizeLimit` to allow large uploads, and disable in‑memory buffering.  
>   - Return JSON `{ success: bool, message: string, metadata: object }` after saving.  
> 
> **3. `/File_Ops`**  
> - **Method**: `POST`  
> - **Request**: JSON `{ "command": "move|copy|delete|list", "sourcePath": "...", "destinationPath": "...", "filePattern": "...", ... }`  
> - **Behavior**:  
>   - **move**: Moves file/folder (streaming if cross-volume).  
>   - **copy**: Copies file/folder using chunked streaming for large files.  
>   - **delete**: Deletes file/folder recursively if needed.  
>   - **list**: Lists directory contents with metadata (name, size, modified date, type), optionally paginated for large directories. 
>   - This endpoint need to use EncryptionCompressionMiddleware for request and response.  
>   - All operations validate and normalize paths, restrict to a configured root directory, and prevent directory traversal.  
>   - Returns JSON `{ success: bool, message: string, details?: object }` for all operations, with consistent error handling and HTTP status codes.  
> 
> **General Requirements**:  
> - Use `.NET 8` Minimal API style in `Program.cs`.  
> - Use async I/O for all file operations.  
> - Log all operations (command, paths, result, errors) for audit/debug.  
> - Ensure concurrency safety for multiple simultaneous operations.  
> - Include try/catch around all file operations with meaningful error messages.  

