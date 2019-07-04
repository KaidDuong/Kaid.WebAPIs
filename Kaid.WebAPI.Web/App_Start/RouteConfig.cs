using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kaid.WebAPI.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /**********
            * url patern static
            ***********/
            //Home
            routes.MapRoute(
                name: "Index",
                url: "index.html",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );

            //Account
            routes.MapRoute(
                name: "Login",
                url: "login.html",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Logout",
                url: "logout.html",
                defaults: new { controller = "Account", action = "Logout", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Register",
                url: "register.html",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional }
                );

           
            //About
            routes.MapRoute(
                name: "About",
                url: "about-us.html",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
                );

            //Contact
            routes.MapRoute(
                name: "Contact",
                url: "contact.html",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
                );

            //Product
            routes.MapRoute(
                name: "Search",
                url: "search.html",
                defaults: new {controller="Product", action= "Search", id=UrlParameter.Optional},
                namespaces: new string[] { "Kaid.WebAPI.Web.Controllers" }
                );

            /*****************
             * url patern have parameter
             ****************/
             //Account
            routes.MapRoute(
              name: "InformationAccount",
              url: "{userName}.a-{userId}.html",
              defaults: new { controller = "Account", action = "Information", UserId = UrlParameter.Optional }
              );

            //Product
            routes.MapRoute(
               name: "Product Category",
               url: "{alias}.pc-{categoryId}.html",
               defaults: new { controller = "Product", action = "Category", categoryId = UrlParameter.Optional }
               );

            routes.MapRoute(
                name: "Product",
                url: "{alias}.p-{productId}.html",
                defaults: new { controller = "Product", action = "Detail", productId = UrlParameter.Optional }
                );


            /*****************
             * url patern default
             * **************/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
