using System.Diagnostics;

namespace WorkerService.Runner.Daemon
{
    public class Daemon : IHostedService, IDisposable
    {
        Timer? _timer;
        private DateTime lastLoad = DateTime.MinValue;
        int mstick = 5000;
        int lastHour = -1;

        public Daemon(){}

        private void TimerTick(object? state)
        {
            _timer?.Change(Timeout.Infinite, 0);
            try
            {
                DateTime now = DateTime.Now;
            }
            finally
            {
                _timer?.Change(mstick, mstick);
            }
        }

        #region Implementación de IHostedService

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _timer = new Timer(TimerTick, null, mstick, mstick);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        #endregion
    }
}
