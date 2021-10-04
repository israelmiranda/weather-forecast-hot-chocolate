using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherForecastHotChocolate.Api.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static string ToJson(this object request)
        {
            return JsonSerializer.Serialize(request,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter() }
                });
        }

        public static T FromJson<T>(this string request)
        {
            return JsonSerializer.Deserialize<T>(request,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                });
        }
    }
}
