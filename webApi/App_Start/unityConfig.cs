using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using webApi.Unity;
using webCore.repository;
using webCore.services;

namespace webApi.App_Start
{
    public class unityConfig
    {
        public static void ConfigureUnity(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IBlog_Repostory, blog_Repostory>();
            container.RegisterType<IBlogServices, blogServices>();
            container.RegisterType<IUser_Repostory, IUser_Repostory>();
            container.RegisterType<IUserServices, userServices>();
            config.DependencyResolver = new UnityResolver(container);
        }

        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IBlog_Repostory, blog_Repostory>();
            container.RegisterType<IBlogServices, blogServices>();
            container.RegisterType<IUser_Repostory, IUser_Repostory>();
            container.RegisterType<IUserServices, userServices>();
            DependencyResolver.SetResolver(new unitytest(container));
        }
    }
}