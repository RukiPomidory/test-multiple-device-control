namespace DeviceControl
{
    public class AnalogDeviceFactory : IDeviceFactory
    {
        public Device CreateDevice()
        {
            var device = new DefaultDevice();
            var analogDevice = new AnalogDevice(device);
            
            return analogDevice;
        }
    }
}