using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pbalut.RealTimeHomeController.HardwareController.Engines
{
    public class LightEngine
    {
        private static LightEngine _lightEngine;
        private Task _task;
        private CancellationTokenSource _cancellationTokenSource;
        public string Field { get; set; }

        public static LightEngine GetLightEngine()
        {
            return _lightEngine ?? (_lightEngine = new LightEngine());
        }

        public void Start()
        {
            if (_task == null)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                //task = new Task(() => ShowHeartRateBlinking(cancellationTokenSource.Token),
                   //_cancellationTokenSource.Token);
                _task.Start();
            }
        }

        public void Stop()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _task = null;
            }
        }
    }
}
