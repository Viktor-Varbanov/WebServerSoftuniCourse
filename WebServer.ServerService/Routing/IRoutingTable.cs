using WebServer.ServerService.Http;

namespace WebServer.ServerService.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(HttpMethod httpMethod, string path, HttpResponse response);

        IRoutingTable MapGet(string path, HttpResponse response);

        IRoutingTable MapPost(string path, HttpResponse response);

        HttpResponse MatchRequest(HttpRequest httpRequest);
    }
}