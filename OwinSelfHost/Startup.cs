using System.Web.Http;
using Autofac;
using Owin;
using OwinSelfHost.Middlewares;

namespace OwinSelfHost
{
    public class Startup
    {
        #region  Private Fields

        private IContainer _container;

        #endregion

        #region Public Methods

        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseRestAuthentication();

            // Configure Web API for self-host. 
            HttpConfiguration httpConfig = new HttpConfiguration();

            httpConfig.Routes.MapHttpRoute("QuotesApi", "{apiVersion}/quotes", new {controller = "quotes"});

            appBuilder.UseWebApi(httpConfig);
        }

        #endregion
    }
}