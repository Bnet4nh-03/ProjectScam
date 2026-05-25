using System.Text.Json;

namespace ATV_Common_WebAPI.Common.Models
{
    public class BaseModel
    {
        public class BaseResponse
        {
            public int code { set; get; }
            public string message { set; get; } = string.Empty;
            public JsonElement? body { set; get; }
        }
    }
}
