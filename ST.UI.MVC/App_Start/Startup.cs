﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ST.UI.MVC.App_Start.Startup))]

namespace ST.UI.MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")    // Daha sonra account login path'i verilecek.
            });
        }
    }
}
