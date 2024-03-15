using System.Net;

namespace DAWN2.Types;

public class WebServer
{
    public WebServerConfig Config { get; set; }

    internal Dictionary<string, Action> mappings { get; set; }
    internal HttpListener listener { get; set; }
    internal HttpClient client { get; set; }
    
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