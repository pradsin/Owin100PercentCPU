using Microsoft.Owin.Hosting;

namespace OwinSelfHost
{
    public class Server
    {
        #region  Private Fields

        private readonly string _baseAddress = "http://localhost:8002/";

        #endregion

        #region Constructor's and Destructor 

        public Server(string baseAddress)
        {
            if (!string.IsNullOrEmpty(baseAddress))
            {
                _baseAddress = baseAddress;
            }
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            WebApp.Start<Startup>(_baseAddress);
        }

        #endregion
    }
}