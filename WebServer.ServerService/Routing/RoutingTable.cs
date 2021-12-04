using System;
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

        public IRoutingTable Map(string url, HttpMethod httpMethod, HttpResponse response)
        {
            return httpMethod switch
            {
                HttpMethod.Get => MapGet(url, response),
                _ => throw new ArgumentException()
            };
        }

        public IRoutingTable MapGet(string url, HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            _routes[HttpMethod.Get][url] = response;
            return this;
        }

        public HttpResponse MatchRequest(HttpRequest httpRequest)
        {
            var requestHttpMethod = httpRequest.Method;
            var url = httpRequest.Url;

            if (!_routes.ContainsKey(requestHttpMethod) ||
                _routes[requestHttpMethod].ContainsKey(url))
            {
                return new NotFoundResponse();
            }

            return _routes[requestHttpMethod][url];
        }
    }
}