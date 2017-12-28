using Antimwpb;
using Google.Protobuf;

using System;

namespace AntiMwSdk.Core.Ipc
{
    public interface IIpcOutput
    {
        event EventHandler<byte[]> IpcReceived;
    }
}
