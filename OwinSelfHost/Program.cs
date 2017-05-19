using System;

namespace OwinSelfHost
{
    static class Program
    {
        #region Private Methods

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Server server = new Server("http://localhost:8002/");
            server.Start();

            Console.ReadKey();
        }

        #endregion
    }
}