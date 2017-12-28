using AntiMwSdk.Core;
using System;
using System.Threading;

namespace AntiMwSdk.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new AntimwApi();
            var threatHandler = new ThreatHandler();

            var client = new AntimwConnectedSdk(api, threatHandler);

            try
            {
                Console.WriteLine($"{ client.StartRealTime() }");

                Thread.Sleep(5000);

                Console.WriteLine($"{ client.StartOnDemand() }");

                Thread.Sleep(30000);
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
