using UnityEngine;

namespace DeviceControl
{
    public class DiscreteDevice : DeviceDecorator
    {
        public DiscreteDevice(Device device) : base(device)
        {
            this.device.AddCommand(new InstantCommand(this));
        }
    }
}