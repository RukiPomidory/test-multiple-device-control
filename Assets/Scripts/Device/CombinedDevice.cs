namespace DeviceControl
{
    public class CombinedDevice : DeviceDecorator
    {
        public CombinedDevice(Device device) : base(device)
        {
            this.device.AddCommand(new InstantCommand(this));
            this.device.AddCommand(new SmoothCommand(this));
        }
    }
}