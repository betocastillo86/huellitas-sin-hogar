﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LoginCol.Huellitas.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
               name: "ApiFiltroPorTipoContenido",
               routeTemplate: "api/{controller}/tip-{idTipoContenido}/{esPadre}",
               defaults: new { controller = "AdminContenidos", esPadre = RouteParameter.Optional},
               constraints: new { idTipoContenido = @"\d+", esPadre = "(true|false)+" }
           );
            
            config.Routes.MapHttpRoute(
               name: "ApiFiltroPorContenido",
               routeTemplate: "api/{controller}/cid-{idContenido}/{idTipoContenido}",
               defaults: new { controller = "AdminContenidosRelacionados", idTipoContenido = RouteParameter.Optional },
               constraints: new { idContenido = @"\d+" }
           );


            config.Routes.MapHttpRoute(
               name: "ApiHuellitas",
               routeTemplate: "api/huellitas",
               defaults: new { controller = "HuellitasApi", idTipoContenido = RouteParameter.Optional }
           );


            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            
     
            
            
            
           

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
