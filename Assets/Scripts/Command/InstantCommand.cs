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
            device.SetState(target);
            OnFinish?.Invoke();
        }

        public override void Stop()
        {
            
        }
    }
}