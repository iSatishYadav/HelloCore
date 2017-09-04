using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using HelloCore.Api.Services;

namespace HelloCore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
            #region Json Properties as Property names
                //.AddJsonOptions(o =>
                //      {
                //          if (o.SerializerSettings.ContractResolver != null)
                //          {
                //              var resolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                //              resolver.NamingStrategy = null;
                //          }
                //      })
            #endregion
            #region Add XML output formatter
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
            #endregion
            ;
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddNLog();

            app.AddNLogWeb();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            #region Error Code Page
            app.UseStatusCodePages();
            #endregion
            #region Just MVC
            app.UseMvc();
            #endregion

            #region Use for MVC, for Web-API use attibute routing
            //app.UseMvc(conf =>
            //{
            //    conf.MapRoute(
            //        name: "Default",
            //        template: "{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" }
            //        );
            //}); 
            #endregion


            #region Hello World 
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //}); 
            #endregion
            #region Exception
            //app.Run(async (context) =>
            //{
            //    throw new Exception("What an Exception");
            //}); 
            #endregion
        }
    }
}
