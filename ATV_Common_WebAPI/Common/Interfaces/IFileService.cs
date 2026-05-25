using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using ATV_Common_WebAPI.Common.Models;

namespace ATV_Common_WebAPI.Common.Interfaces
{
    /// <summary>
    /// Defines the contract for a service that handles file operations.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Gets a file as a stream for downloading.
        /// </summary>
        /// <param name="filePath">The relative path of the file to retrieve.</param>
        /// <returns>A tuple containing the file's stream, content type, and download name.</returns>
        Task<(Stream stream, string contentType, string fileDownloadName)> GetFileAsync(string filePath, string fileName);

        /// <summary>
        /// Saves an uploaded file.
        /// </summary>
        /// <param name="setFileInfo">The setFileInfo associated with the file.</param>
        /// <param name="file">The uploaded file.</param>
        /// <returns>A response indicating the operation's result.</returns>
        Task<object> SaveFileAsync(SetFileInfo setFileInfo, Stream fileStream, string fileName);
        Task<object> PerformFileOperationAsync(FileOperationRequest request);

        /// <summary>
        /// Handles the entire HTTP GET file request, including streaming the response.
        /// </summary>
        /// <param name="context">The HttpContext of the request.</param>
        /// <param name="request">The file request details.</param>
        Task HandleGetFileRequestAsync(HttpContext context, GetFileRequest request);

        /// <summary>
        /// Handles the entire HTTP SET file request, including reading from the multipart form.
        /// </summary>
        /// <param name="context">The HttpContext of the request.</param>
        /// <returns>A response indicating the operation's result.</returns>
        Task<object> HandleSetFileRequestAsync(HttpContext context);
    }
}
