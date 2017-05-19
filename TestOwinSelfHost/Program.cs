using System;
using System.Net;
using System.Text;
using System.Threading;

namespace TestOwinSelfHost
{
    static class Program
    {
        #region Private Methods

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(Start)
                {
                    IsBackground = true,
                    Priority = ThreadPriority.BelowNormal
                };
                thread.Start();
            }


            Console.ReadKey();
        }

        private static void Start()
        {
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Custom SessionID=DFA05EB6-9A05-42B6-83F7-FFD8B7C442CD,UserToken=3706AED7");
            client.Headers.Add("Content-Type", "application/json");
            client.Headers.Add("Origin", "https://loadtesting-cti.i3clogic.com");

            while (true)
            {
                try
                {
                    string response = client.UploadString("http://localhost:8002/v1.1/quotes", "OPTIONS", string.Empty);
                    Console.WriteLine(response);

                    byte[] dataBytes = client.DownloadData("http://localhost:8002/v1.1/quotes");
                    string data = Encoding.UTF8.GetString(dataBytes);
                    Console.WriteLine(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        #endregion
    }
}