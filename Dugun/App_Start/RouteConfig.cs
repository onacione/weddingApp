using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dugun
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));
              routes.MapRoute(name: "Index", url: "", defaults: new { controller = "Home", action = "Index" });
            routes.MapRoute(name: "TableSettings", url: "TableSettings", defaults: new { controller = "Home", action = "TableSettings" });
            routes.MapRoute(name: "Notes", url: "Notes", defaults: new { controller = "Home", action = "Notes" });
            routes.MapRoute(name: "Guests", url: "Guests", defaults: new { controller = "Home", action = "Guests" });
            routes.MapRoute(name: "Categories", url: "Categories", defaults: new { controller = "Home", action = "Categories" });
            routes.MapRoute(name: "Post", url: "Post/{postID}", defaults: new { controller = "Home", action = "Post" });
            routes.MapRoute(name: "PostList", url: "PostList/{categoryID}", defaults: new { controller = "Home", action = "PostList" });

            routes.MapRoute(name: "Adss", url: "Adss/{val}", defaults: new { controller = "Home", action = "Adss" });
            routes.MapRoute(name: "Lggn2346", url: "Lggn2346", defaults: new { controller = "Home", action = "Lggn2346" });
            routes.MapRoute(name: "CommentSettings", url: "CommentSettings", defaults: new { controller = "Home", action = "CommentSettings" });
            routes.MapRoute(name: "SingleBlog", url: "SingleBlog/{postID}", defaults: new { controller = "Home", action = "SingleBlog" });
            routes.MapRoute(name: "SetComment", url: "SetComment", defaults: new { controller = "Home", action = "SetComment" });
           
        }
    }
}
