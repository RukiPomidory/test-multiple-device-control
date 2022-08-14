namespace DeviceControl
{
    public class CombinedDevice : DeviceDecorator
    {
        public CombinedDevice(Device device) : base(device)
        {
            var instantFactory = new InstantCommandFactory();
            var smoothFactory = new SmoothCommandFactory();
            
            this.device.AddCommand(instantFactory.Create(this));
            this.device.AddCommand(smoothFactory.Create(this));
        }
    }
}