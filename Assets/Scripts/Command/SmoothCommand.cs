using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace DeviceControl
{
    public class SmoothCommand : IterativeCommand
    {
        private Vector3 startValue;
        private Vector3 targetValue;
        
        public SmoothCommand(Device device, float duration = 1.5f)
        {
            this.device = device;
            Duration = duration;
        }

        public override void Stop()
        {
            if (!InProgress())
                return;
            
            cancellationSource.Cancel();
            OnFinish?.Invoke();
        }

        protected override void Prepare(Vector3 target)
        {
            lock (device)
            {
                startValue = device.Position;
            }

            targetValue = target;
        }

        protected override void Iterate(float progress, CancellationToken cancelToken)
        {
            var newValue = startValue * (1 - progress) + targetValue * progress;
            
            if (progress >= 1)
                newValue = targetValue;

            if (!cancelToken.IsCancellationRequested)
            {
                lock (device)
                {
                    device.SetPosition(newValue);
                }
            }
        }
    }
}