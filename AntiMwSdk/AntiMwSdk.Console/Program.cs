using Antimwpb;
using AntiMwSdk.Core;
using AntiMwSdk.Core.Ipc;
using AntiMwSdk.CSharpApi.Ipc;
using System.Threading;

namespace AntiMwSdk.Console
{
    class ConsoleThreatHandler : IThreatHandler
    {
        public void Handle(ThreatEvent threatEvent)
        {
            System.Console.WriteLine($"[{ threatEvent.DateTime?.ToLocalTime() }] Real Time threat ({ threatEvent.Name }) detected @ { threatEvent.Path }");
        }

        public void Handle(ThreatLogEvent threatLogEvent)
        {
            System.Console.WriteLine($"[{ threatLogEvent.DateTime?.ToLocalTime() }] On Demand scan threat log: ");
            foreach (var threat in threatLogEvent.Threats)
            {
                Handle(threat);
            }
        }

        public void Handle(LogEvent logEvent)
        {
            System.Console.WriteLine($"[{ logEvent.DateTime?.ToLocalTime() }] Server event ({ logEvent.Type }) { logEvent.Text }");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ZmqIpcOutput ipcOutput = new ZmqIpcOutput();

            try
            {
                var ipcInput = new ZmqIpcInput();
                var threatHandler = new ConsoleThreatHandler();
                var antimwApi = new AntimwConnectedApi(threatHandler, ipcInput, ipcOutput);

                System.Console.WriteLine($"START REAL TIME: { antimwApi.StartRealTime() }");

                Thread.Sleep(2500);

                System.Console.WriteLine($"START ON DEPAND: { antimwApi.StartOnDemand() }");

                Thread.Sleep(10000);

                System.Console.WriteLine($"STOP REAL TIME: { antimwApi.StopRealTime() }");

                Thread.Sleep(15000);
            }
            finally
            {
                ipcOutput.Dispose();
            }
        }
    }
}
