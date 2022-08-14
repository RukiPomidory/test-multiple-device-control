using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace DeviceControl
{
    public class SmoothCommand : Command
    {
        private Task transition;
        private CancellationTokenSource cancellationSource;
        
        public float Duration { get; protected set; }

        public SmoothCommand(Device device, float duration = 1.5f)
        {
            this.device = device;
            Duration = duration;
        }
        
        protected override void Process(Vector3 target)
        {
            OnStarted?.Invoke();
            
            cancellationSource = new CancellationTokenSource();
            transition = RunTransition(target, cancellationSource.Token);
            transition.ContinueWith(task => cancellationSource.Dispose());
        }

        public override void Stop()
        {
            if (!InProgress())
                return;
            
            cancellationSource.Cancel();
            OnFinish?.Invoke();
        }

        private Task RunTransition(Vector3 target, CancellationToken cancelToken)
        {
            // TODO выделить отдельный класс ContinuousCommand для продолжительных команд
            
            var startTime = DeviceUtils.LocalTime();
            var startValue = device.Position;
            var delta = DeviceUtils.GetTaskDeltaMilliseconds();
            
            // Чтобы точно успеть все сделать за ожидаемый Duration
            var duration = Duration * 0.98f;
            
            return Task.Factory.StartNew(() =>
            {
                float progress = 0;

                while (progress < 1)
                {
                    if (cancelToken.IsCancellationRequested)
                        return;
                    
                    var time = DeviceUtils.LocalTime();
                    progress = (time - startTime) / duration;
                    progress = Mathf.Clamp01(progress);
                
                    var newValue = startValue * (1 - progress) + target * progress;

                    if (progress >= 1)
                        newValue = target;

                    if (!cancelToken.IsCancellationRequested)
                    {
                        lock (device)
                        {
                            device.SetPosition(newValue);
                        }
                    }

                    Thread.Sleep(delta);
                }
            }, cancelToken);
        }
        
        private bool InProgress()
        {
            if (transition == null)
                return false;
            
            return transition.Status.Equals(TaskStatus.Running);
        }
    }
}