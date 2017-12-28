using AntiMwSdk.Core.Ipc;
using System;
using ZeroMQ;

namespace AntiMwSdk.CSharpApi.Ipc
{
    public class ZmqIpcInput : IIpcInput
    {
        public string SendCommand(string command)
        {
            using (var requester = new ZSocket(ZSocketType.REQ))
            {
                requester.Connect("tcp://localhost:2804");
                requester.Send(new ZFrame(command));

                using (var reply = requester.ReceiveFrame())
                {
                    return reply.ReadString();
                }
            }
        }
    }
}
