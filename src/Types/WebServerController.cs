using Newtonsoft.Json;

namespace DAWN2.Types;

public class WebServerController
{
    public Dictionary<string, ControllerEndpoint> Mappings { get; set; }

    public void AddMapping(string route, ControllerEndpoint endpoint) => Mappings.Add(route, endpoint);
    
    public void AddGetMapping(string route, ControllerEventHandler handler)
    {
        Mappings.Add(route, new ControllerEndpoint(route, HttpMethod.Get, handler));
    }
}

public class ControllerEndpoint
{
    public string Route { get; set; }
    public HttpMethod Method { get; set; }

    public event ControllerEventHandler? OnCalled;
    public event ControllerErroredEventHandler? OnError;

    public ControllerEndpoint(string route, HttpMethod method, ControllerEventHandler? handler)
    {
        Route = route;
        Method = method;
        OnCalled = handler;
    }

    internal async Task<WebServerResponse> InvokeAsync(HttpRequestMessage message)
    {
        DateTime timestamp = DateTime.UtcNow;
        HttpContent stream = message.Content ?? new StringContent("");

        ControllerCalledEventArgs args = new(this, timestamp, message);
        
        WebServerResponse resp = OnEndpointCalled(args);
        return resp;
    }

    private WebServerResponse OnEndpointCalled(ControllerCalledEventArgs e)
    {
        ControllerEventHandler? handler = OnCalled;

        if(handler is null)
        {
            Console.WriteLine("Failed to invoke: " + Route + ", handler was null!");
            return new(null);
        }

        try
        {
            WebServerResponse resp = handler(this, e);
            return resp;
        } catch (Exception ex) {
            if(OnError is null)
            {
                return WebServerResponse.Error(ex.Message);
            }

            return OnError(this, new ControllerErroredEventArgs(this, ex));
        }
    }
}