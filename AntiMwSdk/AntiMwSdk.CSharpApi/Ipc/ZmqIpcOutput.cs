using System;
using Antimwpb;
using AntiMwSdk.Core.Ipc;
using System.Threading.Tasks;
using System.Threading;
using ZeroMQ;

namespace AntiMwSdk.CSharpApi.Ipc
{
    public class ZmqIpcOutput : IIpcOutput, IDisposable
    {
        public event EventHandler<byte[]> IpcReceived;

        private readonly CancellationTokenSource _cts;

        public ZmqIpcOutput()
        {
            _cts = new CancellationTokenSource();

            Task.Factory.StartNew(Listen, _cts.Token);
        }

        private void Listen()
        {
            using (var subscriber = new ZSocket(ZSocketType.SUB))
            {
                subscriber.Connect("tcp://localhost:1405");
                subscriber.SubscribeAll();

                while (true)
                {
                    if (_cts.IsCancellationRequested)
                    {
                        break;
                    }

                    try
                    {
                        using (var replyFrame = subscriber.ReceiveFrame(ZSocketFlags.DontWait, out ZError error))
                        {
                            if (replyFrame != null)
                            {
                                var replyBytes = replyFrame.Read();

                                var evt = IpcReceived;
                                if (evt != null)
                                    evt(this, replyBytes);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Thread.Sleep(1);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _cts.Cancel();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ZmqIpcOutput() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
