using Owin;

namespace OwinSelfHost.Middlewares
{
    public static class AppBuilderExtensions
    {
        #region Public Methods

        public static IAppBuilder UseRestAuthentication(this IAppBuilder appBuilder)
        {
            return appBuilder.Use<RestAuthentication>();
        }

        #endregion
    }
}