using UnityEngine;

namespace DeviceControl
{
    public class InstantCommand : Command
    {
        private Device device;
        
        public InstantCommand(Device device)
        {
            this.device = device;
        }
        
        public override void Execute(Vector3 target)
        {
            device.SetPosition(target);
            OnFinish?.Invoke();
        }

        public override void Stop()
        {
            
        }
    }
}