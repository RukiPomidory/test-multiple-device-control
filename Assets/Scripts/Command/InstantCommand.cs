using UnityEngine;

namespace DeviceControl
{
    public class InstantCommand : Command
    {
        private DiscreteDevice device;
        
        public InstantCommand(DiscreteDevice device)
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