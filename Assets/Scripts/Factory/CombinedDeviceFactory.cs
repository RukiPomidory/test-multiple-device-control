namespace DeviceControl
{
    public class CombinedDeviceFactory : IDeviceFactory
    {
        public Device CreateDevice()
        {
            var device = new DefaultDevice();
            var combinedDevice = new CombinedDevice(device);

            return combinedDevice;
        }
    }
}