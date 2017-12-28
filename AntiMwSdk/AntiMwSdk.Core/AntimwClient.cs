using Antimwpb;
using Google.Protobuf;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ZeroMQ;

namespace AntiMwSdk.Core
{
    public class AntimwConnectedSdk : AntimwSdk, IDisposable
    {
        private Thread _thread;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        private readonly IThreatHandler _threadHandler;

        public AntimwConnectedSdk(IAntimwApi antimwApi, IThreatHandler threatHandler) : base(antimwApi)
        {
            _thread = new Thread(Listen);
            _thread.Start(_cts.Token);

            _threadHandler = threatHandler;
        }

        private void Listen(object ct)
        {
            var cancellationToken = (CancellationToken)ct;

            using (var subscriber = new ZSocket(ZSocketType.SUB))
            {
                subscriber.Connect("tcp://localhost:1405");
                subscriber.SubscribeAll();

                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
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

                                var messageDto = MessageDto.Parser.ParseFrom(replyBytes);
                                switch (messageDto.MessageCase)
                                {
                                    case MessageDto.MessageOneofCase.ThreatEventDto:
                                        _threadHandler.Handle(messageDto.ThreatEventDto);

                                        break;

                                    case MessageDto.MessageOneofCase.ThreatLogEventDto:
                                        _threadHandler.Handle(messageDto.ThreatLogEventDto);

                                        break;

                                    case MessageDto.MessageOneofCase.LogEventDto:
                                        _threadHandler.Handle(messageDto.LogEventDto);

                                        break;
                                }
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
        // ~AntimwConnectedSdk() {
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
