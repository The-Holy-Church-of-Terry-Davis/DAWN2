using Newtonsoft.Json;

namespace DAWN2.Types;

public class ControllerErroredEventArgs : EventArgs
{
    public ControllerEndpoint Endpoint { get; set; }
    public Exception Exception { get; set; }

    public ControllerErroredEventArgs(ControllerEndpoint endpoint, Exception ex)
    {
        Endpoint = endpoint;
        Exception = ex;
    }
}

public delegate WebServerResponse ControllerErroredEventHandler(ControllerEndpoint sender, ControllerErroredEventArgs e);