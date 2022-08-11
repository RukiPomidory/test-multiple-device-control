namespace DeviceControl
{
    public abstract class DeviceDecorator : Device
    {
        protected Device device;

        public DeviceDecorator(Device device)
        {
            this.device = device;
        }
    }
}