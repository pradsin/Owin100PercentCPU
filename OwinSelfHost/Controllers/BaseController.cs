using System.Web.Http;

namespace OwinSelfHost.Controllers
{
    public class BaseController : ApiController
    {
        #region Public Methods

        /// <summary>
        ///     Options for all the api's. Override to send specific methods
        /// </summary>
        [HttpOptions]
        public void Options()
        {
        }

        #endregion
    }
}