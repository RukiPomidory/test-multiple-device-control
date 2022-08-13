using UnityEngine;

namespace DeviceControl
{
    public class AnalogDevice : DeviceDecorator
    {

        public AnalogDevice(Device device) : base(device)
        {
            this.device.AddCommand(new SmoothCommand(this));
        }
    }
}