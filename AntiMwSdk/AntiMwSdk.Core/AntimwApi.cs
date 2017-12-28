using ZeroMQ;

namespace AntiMwSdk.Core
{
    public class AntimwApi : IAntimwApi
    {
        public string SendReq(string reqText)
        {
            using (var requester = new ZSocket(ZSocketType.REQ))
            {
                requester.Connect("tcp://localhost:2804");
                requester.Send(new ZFrame(reqText));

                using (var reply = requester.ReceiveFrame())
                {
                    return reply.ReadString();
                }
            }
        }
    }

    public interface IAntimwApi
    {
        string SendReq(string reqText);
    }
}
