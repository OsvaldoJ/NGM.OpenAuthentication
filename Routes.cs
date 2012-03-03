﻿using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace NGM.OpenAuthentication {
    public class Routes : IRouteProvider {

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                             new RouteDescriptor {
                                                     Route = new Route(
                                                         "LogOn/RemoveParameterAssociation",
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"},
                                                                                      {"controller", "Index"},
                                                                                      {"action", "RemoveParameterAssociation"}
                                                                                  },
                                                         new RouteValueDictionary(),
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 },
                             new RouteDescriptor {
                                                     Route = new Route(
                                                         "OAuth/LogOn",
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"},
                                                                                      {"controller", "OAuthAccount"},
                                                                                      {"action", "LogOn"}
                                                                                  },
                                                         new RouteValueDictionary(),
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 },
                             new RouteDescriptor {
                                                     Route = new Route(
                                                         "OAuth/LogOn/{knownProvider}",
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"},
                                                                                      {"controller", "OAuthAccount"},
                                                                                      {"action", "LogOn"}
                                                                                  },
                                                         new RouteValueDictionary(),
                                                         new RouteValueDictionary {
                                                                                      {"area", "NGM.OpenAuthentication"}
                                                                                  },
                                                         new MvcRouteHandler())
                                                 }
                         };
        }
    }
}