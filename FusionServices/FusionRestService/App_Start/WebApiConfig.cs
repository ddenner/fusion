﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FusionRestService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetPatient",
                routeTemplate: "api/{controller}/{patientid}/{region}",
                defaults: new { region = 0 }
                );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            
        }
    }
}
