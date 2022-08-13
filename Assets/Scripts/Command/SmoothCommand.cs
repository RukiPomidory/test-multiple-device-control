using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace DeviceControl
{
    public class SmoothCommand : Command
    {
        private Device device;
        private Task transition;

        public float Duration { get; protected set; }

        public SmoothCommand(Device device, float duration = 1.5f)
        {
            this.device = device;
            Duration = duration;
        }
        
        public override void Execute(Vector3 target)
        {
            var startTime = DeviceUtils.LocalTime();
            var startValue = device.Position;
            var delta = DeviceUtils.GetTaskDeltaMilliseconds();
            
            // Чтобы точно успеть все провернуть
            var duration = Duration * 0.98f;
            
            Task.Run(() =>
            {
                float progress = 0;

                while (progress < 1)
                {
                    var time = DeviceUtils.LocalTime();
                    progress = (time - startTime) / duration;
                    progress = Mathf.Clamp01(progress);
                
                    var newValue = startValue * (1 - progress) + target * progress;

                    if (progress >= 1)
                        newValue = target;
                    
                    device.SetPosition(newValue);
                    
                    
                    Thread.Sleep(delta);
                }
            });
        }
        
        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}