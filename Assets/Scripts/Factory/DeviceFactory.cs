namespace DeviceControl
{
    public abstract class DeviceFactory : IDeviceFactory
    {
        public abstract Device CreateDevice();

        public virtual Device CreateDevice(string name)
        {
            var device = CreateDevice();
            device.Name = name;
            
            return device;
        }
    }
}