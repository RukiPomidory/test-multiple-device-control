using UnityEngine;

namespace DeviceControl
{
    public class AnalogDevice : DeviceDecorator
    {

        public AnalogDevice(Device device) : base(device)
        {
            var factory = new SmoothCommandFactory();
            
            this.device.AddCommand(factory.Create(this));
        }
    }
}