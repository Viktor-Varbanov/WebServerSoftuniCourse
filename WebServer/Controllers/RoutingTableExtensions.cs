﻿using System;
using WebServer.Http;
using WebServer.Routing;

namespace WebServer.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
            => routingTable.MapGet(path, request =>
            {
                var controller = (TController)Activator.CreateInstance(typeof(TController), new[] { request });

                return controllerFunction(controller);
            });

        public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
            => routingTable.MapPost(path, request =>
            {
                var controller = (TController)Activator.CreateInstance(typeof(TController), new[] { request });

                return controllerFunction(controller);
            });
    }
}