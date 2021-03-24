using System.Text.Json;

namespace BlazorApiExample.Models
{
    public static class SerializerOptions
    {
        public static JsonSerializerOptions JsonOptions => new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            IgnoreReadOnlyProperties = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}