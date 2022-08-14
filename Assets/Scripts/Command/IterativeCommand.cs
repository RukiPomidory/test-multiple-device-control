using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace DeviceControl
{
    public abstract class IterativeCommand : Command
    {
        protected Task transition;
        protected CancellationTokenSource cancellationSource;
        
        public float Duration { get; protected set; }
        
        public bool InProgress()
        {
            if (transition == null)
                return false;
            
            return transition.Status.Equals(TaskStatus.Running);
        }
        
        protected override void Process(Vector3 target)
        {
            OnStarted?.Invoke();
            
            cancellationSource = new CancellationTokenSource();
            transition = RunTransition(target, cancellationSource.Token);
            transition.ContinueWith(task =>
            {
                if (!cancellationSource.IsCancellationRequested)
                    OnFinish?.Invoke();
                
                cancellationSource.Dispose();
            });
        }
        
        private Task RunTransition(Vector3 target, CancellationToken cancelToken)
        {
            Prepare(target);
            
            var startTime = DeviceUtils.LocalTime();
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
                
                    Iterate(progress, cancelToken);

                    Thread.Sleep(delta);
                }
            }, cancelToken);
        }

        protected abstract void Prepare(Vector3 target);
        
        protected abstract void Iterate(float progress, CancellationToken cancellationToken);
    }
}