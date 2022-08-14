using UnityEngine;

namespace DeviceControl
{
    public class InstantCommand : Command
    {
        public InstantCommand(Device device)
        {
            this.device = device;
        }
        
        protected override void Process(Vector3 target)
        {
            OnStarted?.Invoke();
            device.SetPosition(target);
            OnFinish?.Invoke();
        }

        public override void Stop()
        {
            
        }
    }
}