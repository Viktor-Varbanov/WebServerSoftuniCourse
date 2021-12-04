using WebServer.ServerService.Http;

namespace WebServer.ServerService.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HttpMethod httpMethod, HttpResponse response);

        IRoutingTable MapGet(string url, HttpResponse response);

        HttpResponse MatchRequest(HttpRequest httpRequest);
    }
}