using Microsoft.Owin.Security;

namespace OwinSelfHost.Middlewares
{
    public class RestAuthenticationOptions : AuthenticationOptions
    {
        #region Constructor's and Destructor 

        public RestAuthenticationOptions() : base("Custom")
        {
            AuthenticationMode = AuthenticationMode.Active;
        }

        #endregion
    }
}