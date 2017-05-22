using System;
using System.Diagnostics;
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

        #endregion

        #region Constructor's and Destructor 

        public RestAuthenticationHandler()
        {
            _authParamRegex = new Regex(@"SessionID\s*=\s*(?<sessionid>[^,\s]+?)\s*,\s*UserToken\s*=\s*(?<usertoken>[^,\s]+)", RegexOptions.Singleline);
        }

        #endregion

        #region Public Methods

        public override async Task<bool> InvokeAsync()
        {
            bool fail = true;

            try
            {
                string[] authVal;

                if (Request.Headers.TryGetValue("Authorization", out authVal))
                {
                    foreach (string s in authVal)
                    {
                        AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(s);
                        if (authHeader.Scheme != "Custom")
                        {
                            continue;
                        }

                        if (string.IsNullOrEmpty(authHeader.Parameter))
                        {
                            fail = true;
                        }
                        else
                        {
                            Match match = _authParamRegex.Match(authHeader.Parameter);

                            if (!match.Success)
                            {
                                continue;
                            }

                            if ((match.Groups["sessionid"].Value == "DFA05EB6-9A05-42B6-83F7-FFD8B7C442CD") && (match.Groups["usertoken"].Value == "3706AED7"))
                            {
                                fail = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            return await Task.FromResult(fail);
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