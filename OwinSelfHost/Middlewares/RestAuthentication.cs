using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;

namespace OwinSelfHost.Middlewares
{
    public class RestAuthentication : AuthenticationMiddleware<RestAuthenticationOptions>
    {
        #region  Private Fields

        private readonly RestAuthenticationHandler _authHandler;

        #endregion

        #region Constructor's and Destructor 

        public RestAuthentication(OwinMiddleware next) : base(next, new RestAuthenticationOptions())
        {
            _authHandler = new RestAuthenticationHandler();
        }

        #endregion

        #region Protected Methods

        protected override AuthenticationHandler<RestAuthenticationOptions> CreateHandler()
        {
            return _authHandler;
        }

        #endregion
    }
}