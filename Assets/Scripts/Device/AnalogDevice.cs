using UnityEngine;

namespace DeviceControl
{
    public class AnalogDevice : DeviceDecorator
    {
        public AnalogDevice(Device device) : base(device)
        {
            var smoothCommand = new SmoothCommand();
            this.device.AddCommand(smoothCommand);
        }
    }
}