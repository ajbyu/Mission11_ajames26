using Microsoft.AspNetCore.Http;

namespace Mission11_ajames26.Infrastructure
{
    public static class UrlExtensions
    {
        //Extract path and query from request
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
