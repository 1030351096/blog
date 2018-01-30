using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using webApi.App_Start;
using webApi.Attribute;
using webApi.Unity;
using webCore.repository;
using webCore.services;

namespace webApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            unityConfig.ConfigureUnity(config);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();


            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //api身份过滤器
            config.Filters.Add(new chechkFilterAttribute());
        }
    }
}
