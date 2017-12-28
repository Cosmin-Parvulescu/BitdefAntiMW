using Antimwpb;
using AntiMwSdk.Core.Ipc;
using System;
using System.Threading;

namespace AntiMwSdk.Core
{
    public class AntimwConnectedApi : AntimwApi, IDisposable
    {
        private readonly IThreatHandler _threadHandler;
        private readonly IIpcOutput _ipcOutput;

        public AntimwConnectedApi(IThreatHandler threatHandler, IIpcInput ipcInput, IIpcOutput ipcOutput) : base(ipcInput)
        {
            _threadHandler = threatHandler;

            _ipcOutput = ipcOutput;
            _ipcOutput.IpcReceived += _ipcOutput_IpcReceived;
        }

        private void _ipcOutput_IpcReceived(object sender, byte[] e)
        {
            var messageDto = MessageDto.Parser.ParseFrom(e);

            _ipcOutput_IpcReceived(sender, messageDto);
        }

        private void _ipcOutput_IpcReceived(object sender, MessageDto message)
        {
            switch (message.MessageCase)
            {
                case MessageDto.MessageOneofCase.ThreatEventDto:
                    _threadHandler.Handle(ThreatEvent.Build(message.ThreatEventDto));

                    break;

                case MessageDto.MessageOneofCase.ThreatLogEventDto:
                    _threadHandler.Handle(ThreatLogEvent.Build(message.ThreatLogEventDto));

                    break;

                case MessageDto.MessageOneofCase.LogEventDto:
                    _threadHandler.Handle(LogEvent.Build(message.LogEventDto));

                    break;
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
                    _ipcOutput.IpcReceived -= _ipcOutput_IpcReceived;
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
