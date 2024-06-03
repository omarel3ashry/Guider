using System.Text.Json.Serialization;

namespace Guider.Application.Responses
{
    public class BaseResponse<T>
    {
        [JsonPropertyOrder(-1)]
        public bool Success { get; set; } = true;
        [JsonPropertyOrder(-1)]
        public string Message { get; set; } = string.Empty;
        public T Result { get; set; }
    }
}
