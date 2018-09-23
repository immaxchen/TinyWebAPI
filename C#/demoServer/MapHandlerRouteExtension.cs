using System.Web.Compilation;

namespace System.Web.Routing
{
    public static class MapHandlerRouteExtension
    {
        public static void MapHandlerRoute(this RouteCollection routes, string routeName, string routeUrl, string physicalFile)
        {
            var route = new Route(routeUrl, new HandlerRouteHandler(physicalFile));
            routes.Add(routeName, route);
        }

        private class HandlerRouteHandler : IRouteHandler
        {
            private string virtualPath = null;

            public HandlerRouteHandler(string physicalFile)
            {
                virtualPath = physicalFile;
            }

            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return (IHttpHandler)BuildManager.CreateInstanceFromVirtualPath(virtualPath, typeof(IHttpHandler));
            }
        }
    }
}