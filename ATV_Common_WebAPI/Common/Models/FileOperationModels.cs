using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ATV_Common_WebAPI.Common.Models
{
    /// <summary>
    /// Request model for the /Get endpoint.
    /// </summary>
    public class GetFileRequest
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }

    /// <summary>
    /// Represents the file info for a file being uploaded via the /Set endpoint.
    /// "SaveMode" -> "Rename" - Rename file and keep file to folder YYYY/MM of destination folder. "KeepName" - Keep file name and save to destination folder.
    /// </summary>
    public class SetFileInfo
    {
        public string AppName { get; set; }
        public string Destination { get; set; }
        public string SaveMode { get; set; } = "Rename";
        public string FileName { get; set; }
        public long FileSize { get; set; }
    }

    /// <summary>
    /// Represents an item in a directory listing.
    /// </summary>
    public class FileListItem
    {
        public string Name { get; set; }
        public long? Size { get; set; } // Nullable for directories
        public string Type { get; set; } // "File" or "Directory"
        public System.DateTime LastModified { get; set; }
    }

    /// <summary>
    /// Represents the root request for a file system operation (e.g., move, copy, list).
    /// This class uses a custom JsonConverter to handle polymorphic deserialization of the 'Operation' property.
    /// </summary>
    // The [JsonConverter] attribute directs the JSON serializer to use the specified custom converter class.
    // This is required here to manually handle polymorphic deserialization, as the 'Command' property (the type discriminator)
    // is a sibling to the 'Operation' object it describes—a pattern System.Text.Json doesn't handle automatically.
    [JsonConverter(typeof(FileOperationRequestConverter))]
    public class FileOperationRequest
    {
        /// <summary>
        /// The command to execute (e.g., "move", "copy", "list"). This determines the type of the 'Operation' object.
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// The details of the operation, deserialized into a specific subclass based on the 'Command'.
        /// </summary>
        public OperationDetails Operation { get; set; }
    }

    /// <summary>
    /// Abstract base class for all file operation details.
    /// </summary>
    public abstract class OperationDetails
    {
        /// <summary>
        /// The primary source path for the operation.
        /// </summary>
        public string SourcePath { get; set; }
    }

    /// <summary>
    /// Details for a 'move' operation.
    /// </summary>
    public class MoveOperationDetails : OperationDetails
    {
        public string DestinationPath { get; set; }
    }

    /// <summary>
    /// Details for a 'copy' operation.
    /// </summary>
    public class CopyOperationDetails : OperationDetails
    {
        public string DestinationPath { get; set; }
    }

    /// <summary>
    /// Details for a 'delete' operation.
    /// </summary>
    public class DeleteOperationDetails : OperationDetails
    {
        public bool Recursive { get; set; }
    }

    /// <summary>
    /// Details for a 'list' operation, including pagination and sorting options.
    /// </summary>
    public class ListOperationDetails : OperationDetails
    {
        public string FilePattern { get; set; }
        public int PageNumber { get; set; } = 1; // Default to page 1
        public int PageSize { get; set; } = 10; // Default to 10 items per page
        public string OrderBy { get; set; } = "name"; // Default to sorting by name
        public bool Ascending { get; set; } = true; // Default to ascending order
        public bool Paginate { get; set; } = true; // Default to paginated results
    }

    /// <summary>
    /// Details for a 'rename' operation.
    /// </summary>
    public class RenameOperationDetails : OperationDetails
    {
        public string NewName { get; set; }
    }

    /// <summary>
    /// Details for a 'createdirectory' operation.
    /// </summary>
    public class CreateDirectoryOperationDetails : OperationDetails
    {
        // No additional properties needed for create directory
    }

    /// <summary>
    /// A custom JSON converter to handle the polymorphic deserialization of the FileOperationRequest class.
    /// This is necessary because the property that determines the type of 'Operation' ('Command')
    /// is a sibling to 'Operation', not a child. System.Text.Json's built-in polymorphism support
    /// requires the type discriminator to be part of the object being deserialized.
    /// This converter manually reads the 'Command' and then uses it to deserialize 'Operation' into the correct concrete type.
    /// </summary>
    public class FileOperationRequestConverter : JsonConverter<FileOperationRequest>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(FileOperationRequest).IsAssignableFrom(typeToConvert);
        }

        public override FileOperationRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException("Expected StartObject token");
            }

            // Use JsonDocument to parse the JSON object so we can inspect its properties before full deserialization.
            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDocument.RootElement;
                var request = new FileOperationRequest();

                // 1. Read the 'command' property first. This will act as our type discriminator.
                // We check for both camelCase ('command') and PascalCase ('Command') for flexibility.
                if (!root.TryGetProperty("command", out var commandElement) && !root.TryGetProperty("Command", out commandElement))
                {
                    throw new JsonException("The 'command' property is required.");
                }
                if (commandElement.ValueKind != JsonValueKind.String)
                {
                    throw new JsonException("The 'command' property must be a string.");
                }

                request.Command = commandElement.GetString();

                // 2. Get the 'operation' property, which is a nested JSON object.
                if (!root.TryGetProperty("operation", out var operationElement) && !root.TryGetProperty("Operation", out operationElement))
                {
                    throw new JsonException("The 'operation' property is required.");
                }
                if (operationElement.ValueKind != JsonValueKind.Object)
                {
                    throw new JsonException("The 'operation' property must be an object.");
                }

                // Get the raw JSON text of the 'operation' object. We will deserialize this text separately.
                var operationJson = operationElement.GetRawText();

                // 3. CRITICAL: To deserialize the 'operation' object, we must use a JsonSerializerOptions
                // instance that does NOT include this converter. Otherwise, it will cause an infinite loop.
                var newOptions = new JsonSerializerOptions(options);
                var self = newOptions.Converters.FirstOrDefault(c => c is FileOperationRequestConverter);
                if (self != null)
                {
                    newOptions.Converters.Remove(self);
                }

                // 4. Use the 'command' string to decide which concrete type to deserialize the 'operation' JSON into.
                switch (request.Command.ToLowerInvariant())
                {
                    case "move":
                        request.Operation = JsonSerializer.Deserialize<MoveOperationDetails>(operationJson, newOptions);
                        break;
                    case "copy":
                        request.Operation = JsonSerializer.Deserialize<CopyOperationDetails>(operationJson, newOptions);
                        break;
                    case "delete":
                        request.Operation = JsonSerializer.Deserialize<DeleteOperationDetails>(operationJson, newOptions);
                        break;
                    case "list":
                        request.Operation = JsonSerializer.Deserialize<ListOperationDetails>(operationJson, newOptions);
                        break;
                    case "rename":
                        request.Operation = JsonSerializer.Deserialize<RenameOperationDetails>(operationJson, newOptions);
                        break;
                    case "createdirectory":
                        request.Operation = JsonSerializer.Deserialize<CreateDirectoryOperationDetails>(operationJson, newOptions);
                        break;
                    default:
                        throw new JsonException($"Unknown command '{request.Command}'.");
                }

                return request;
            }
        }

        /// <summary>
        /// Writes the FileOperationRequest object back to JSON.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, FileOperationRequest value, JsonSerializerOptions options)
        {
            // As with the Read method, we must remove this converter from the options before
            // serializing to prevent an infinite loop.
            var newOptions = new JsonSerializerOptions(options);
            var self = newOptions.Converters.FirstOrDefault(c => c is FileOperationRequestConverter);
            if (self != null)
            {
                newOptions.Converters.Remove(self);
            }

            // Use the default serializer with the modified options.
            JsonSerializer.Serialize(writer, value, newOptions);
        }
    }
}
