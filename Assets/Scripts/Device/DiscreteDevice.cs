using UnityEngine;

namespace DeviceControl
{
    public class DiscreteDevice : DeviceDecorator
    {
        public DiscreteDevice(Device device) : base(device)
        {
            var instantCommand = new InstantCommand(this);
            this.device.AddCommand(instantCommand);
        }
    }
}