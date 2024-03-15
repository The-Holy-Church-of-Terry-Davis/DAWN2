using Newtonsoft.Json;

namespace src.Types;

public class ControllerCalledEventArgs : EventArgs
{
    public ControllerEndpoint Endpoint { get; set; }
    public DateTime Timestamp { get; set; }
    public HttpRequestMessage Request { get; set; }

    public ControllerCalledEventArgs(ControllerEndpoint endpoint, DateTime timestamp, HttpRequestMessage request)
    {
        Endpoint = endpoint;
        Timestamp = timestamp;
        Request = request;
    }

    public async Task<T> SerializeContent<T>()
    {
        return JsonConvert.DeserializeObject<T>(await (Request.Content ?? throw new NullReferenceException()).ReadAsStringAsync()) ??
               throw new NullReferenceException();
    }
}

public delegate WebServerResponse ControllerEventHandler(ControllerEndpoint sender, ControllerCalledEventArgs e);