﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Artisaneer
{
    public static class WebApiConfig
    {
       
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "CatchAll",
            //    routeTemplate: "api/{Controller}/{*catchall}",
            //    defaults: new { id = RouteParameter.Optional });

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
                config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t=>t.MediaType == "application/xml"));

          config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling 
        = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
          config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
              = Newtonsoft.Json.PreserveReferencesHandling.Objects; 

            //var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}