using System;
using System.Collections.Generic;
using WebServer.Common;
using WebServer.Http;
using WebServer.Responses;

namespace WebServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> _routes;

        public RoutingTable()
        {
            _routes = new()
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
            return this.Map(httpMethod, path, request => response);
        }

        public IRoutingTable Map(HttpMethod httpMethod, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            _routes[httpMethod][path] = responseFunction;
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

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            throw new NotImplementedException();
        }

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            throw new NotImplementedException();
        }

        public HttpResponse MatchRequest(HttpRequest httpRequest)
        {
            var requestMethod = httpRequest.Method;
            var requestPath = httpRequest.Path;

            if (!_routes.ContainsKey(requestMethod)
                || !_routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            var responseFunction = _routes[requestMethod][requestPath];

            return responseFunction(httpRequest);
        }
    }
}