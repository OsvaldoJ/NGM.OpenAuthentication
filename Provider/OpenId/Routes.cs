using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace NGM.OpenAuthentication.Provider.OpenId {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                             new RouteDescriptor {
                                                     Route = new Route(
                                                         "OpenId/LogOn",
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"},
                                                                                      {"controller", "OpenIdAccount"},
                                                                                      {"action", "LogOn"}
                                                                                  },
                                                         new RouteValueDictionary(),
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 },
                         };
        }
    }
}