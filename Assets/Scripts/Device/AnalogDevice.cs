using UnityEngine;

namespace DeviceControl
{
    public class AnalogDevice : DeviceDecorator
    {
        public float TransitionDuration { get; }

        public AnalogDevice(Device device, float duration = 1.5f) : base(device)
        {
            var smoothCommand = new SmoothCommand(this);
            this.device.AddCommand(smoothCommand);

            TransitionDuration = duration;
        }
    }
}