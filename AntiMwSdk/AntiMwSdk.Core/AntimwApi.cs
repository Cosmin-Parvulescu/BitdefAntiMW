using AntiMwSdk.Core.Ipc;

namespace AntiMwSdk.Core
{
    public class AntimwApi : IAntimwApi
    {
        private IIpcInput _ipc;

        public AntimwApi(IIpcInput ipcInput)
        {
            _ipc = ipcInput;
        }

        public string StartRealTime()
        {
            return _ipc.SendCommand("START_REALTIME");
        }

        public string StopRealTime()
        {
            return _ipc.SendCommand("STOP_REALTIME");
        }

        public string StartOnDemand()
        {
            return _ipc.SendCommand("START_ONDEMAND");
        }

        public string StopOnDemand()
        {
            return _ipc.SendCommand("STOP_ONDEMAND");
        }
    }

    public interface IAntimwApi
    {
        string StartRealTime();
        string StopRealTime();
        string StartOnDemand();
        string StopOnDemand();
    }
}
