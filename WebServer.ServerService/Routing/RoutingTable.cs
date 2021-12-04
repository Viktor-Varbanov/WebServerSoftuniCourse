using System.Collections.Generic;
using WebServer.ServerService.Common;
using WebServer.ServerService.Http;
using WebServer.ServerService.Responses;

namespace WebServer.ServerService.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> _routes;

        public RoutingTable()
        {
            _routes = new Dictionary<HttpMethod, Dictionary<string, HttpResponse>>()
            {
                [HttpMethod.Get] = new(),
                [HttpMethod.Post] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new()
            };
        }

        public IRoutingTable Map(
            HttpMethod httpMethod,
            string path,
            HttpResponse response)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(response, nameof(response));

            _routes[httpMethod][path] = response;
            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
        {
            return Map(HttpMethod.Get, path, response);
        }

        public IRoutingTable MapPost(string path, HttpResponse response)
        {
            return Map(HttpMethod.Post, path, response);
        }

        public HttpResponse MatchRequest(HttpRequest httpRequest)
        {
            var requestHttpMethod = httpRequest.Method;
            var url = httpRequest.Path;

            if (!_routes.ContainsKey(requestHttpMethod) &&
                _routes[requestHttpMethod].ContainsKey(url))
            {
                return new NotFoundResponse();
            }

            return _routes[requestHttpMethod][url];
        }
    }
}