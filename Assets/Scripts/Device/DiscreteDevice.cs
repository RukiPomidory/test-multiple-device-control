using UnityEngine;

namespace DeviceControl
{
    public class DiscreteDevice : DeviceDecorator
    {
        public DiscreteDevice(Device device) : base(device)
        {
            var factory = new InstantCommandFactory();
            this.device.AddCommand(factory.Create(this));
        }
    }
}