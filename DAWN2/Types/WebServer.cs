using System.Net;

namespace DAWN2.Types;

public class WebServer
{
    public WebServerConfig Config { get; set; }

    internal Dictionary<string, Action> Mappings { get; set; }
    internal HttpListener Listener { get; set; }
    internal HttpClient Client { get; set; }
    
    public WebServer(WebServerConfig config)
    {
        Config = config;
    }

    public void RunAppAsync()
    {
        
    }

    public void CreateMapping()
    {
        
    }
}