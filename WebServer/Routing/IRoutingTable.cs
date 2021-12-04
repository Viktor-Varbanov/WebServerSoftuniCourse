using System;
using WebServer.Http;

namespace WebServer.Routing
{
    public interface IRoutingTable
    {
        IRoutingTable Map(HttpMethod httpMethod, string path, HttpResponse response);

        IRoutingTable Map(HttpMethod httpMethod, string path, Func<HttpRequest, HttpResponse> responseFunction);

        IRoutingTable MapGet(string path, HttpResponse response);

        IRoutingTable MapPost(string path, HttpResponse response);

        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction);

        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction);

        HttpResponse MatchRequest(HttpRequest httpRequest);
    }
}