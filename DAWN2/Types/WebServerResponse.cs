using System.Net;

namespace DAWN2.Types;

public class WebServerResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public object? Data { get; set; }

    public WebServerResponse(object? data, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        Data = data;
        StatusCode = statusCode;
    }

    public static WebServerResponse Ok() => new(null);
    public static WebServerResponse NotFound(object? data = null) => new(data, HttpStatusCode.NotFound);
    public static WebServerResponse Error(object? data) => new(data, HttpStatusCode.InternalServerError);
}