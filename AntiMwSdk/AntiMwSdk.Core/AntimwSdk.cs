namespace AntiMwSdk.Core
{
    public class AntimwSdk : IAntimwSdk
    {
        private readonly IAntimwApi _api;

        public AntimwSdk(IAntimwApi antimwApi)
        {
            _api = antimwApi;
        }

        public string StartRealTime()
        {
            return _api.SendReq("START_REALTIME");
        }

        public string StopRealTime()
        {
            return _api.SendReq("STOP_REALTIME");
        }

        public string StartOnDemand()
        {
            return _api.SendReq("START_ONDEMAND");
        }

        public string StopOnDemand()
        {
            return _api.SendReq("STOP_ONDEMAND");
        }
    }

    public interface IAntimwSdk
    {
        string StartRealTime();
        string StopRealTime();
        string StartOnDemand();
        string StopOnDemand();
    }
}
