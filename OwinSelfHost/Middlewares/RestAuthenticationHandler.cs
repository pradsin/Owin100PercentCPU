using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;

namespace OwinSelfHost.Middlewares
{
    public class RestAuthenticationHandler : AuthenticationHandler<RestAuthenticationOptions>
    {
        #region  Private Fields

        private readonly Regex _authParamRegex;
        private readonly Regex _wavFileRegex;

        #endregion

        #region Constructor's and Destructor 

        public RestAuthenticationHandler()
        {
            _authParamRegex = new Regex(@"SessionID\s*=\s*(?<sessionid>[^,\s]+?)\s*,\s*UserToken\s*=\s*(?<usertoken>[^,\s]+)", RegexOptions.Singleline);
            _wavFileRegex = new Regex(@"^.*\/campaigns\/.+\/tones\/.+\.wav$", RegexOptions.Singleline);
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public override async Task<bool> InvokeAsync()
        {
            return await Task.Run(() =>
            {

                try
                {
                    string[] authVal;

                    if (Request.Headers.TryGetValue("Authorization", out authVal))
                    {
                        foreach (string a in authVal)
                        {
                            AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(a);
                            if (authHeader.Scheme != "Custom")
                            {
                                continue;
                            }

                            if (string.IsNullOrEmpty(authHeader.Parameter))
                            {
                                return true;
                            }

                            Match match = _authParamRegex.Match(authHeader.Parameter);

                            if (!match.Success)
                            {
                                continue;
                            }

                            if ((match.Groups["sessionid"].Value == "DFA05EB6-9A05-42B6-83F7-FFD8B7C442CD") && (match.Groups["usertoken"].Value == "3706AED7"))
                            {
                                return false;
                            }

                            return true;
                        }
                    }

                    return true;
                }
                catch
                {
                    return true;
                }
            });
        }

        #endregion

        #region Protected Methods

        protected override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            return Task.FromResult<AuthenticationTicket>(null);
        }

        #endregion
    }
}