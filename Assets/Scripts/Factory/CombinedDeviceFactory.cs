namespace DeviceControl
{
    public class CombinedDeviceFactory : DeviceFactory
    {
        public override Device CreateDevice()
        {
            var device = new DefaultDevice();
            var combinedDevice = new CombinedDevice(device);

            return combinedDevice;
        }
    }
}