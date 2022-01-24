using System.Text.Json;

namespace Upwork.ElasticSearch_Net;

public static class ApiConsts {
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}
