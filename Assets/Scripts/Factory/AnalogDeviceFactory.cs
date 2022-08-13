namespace DeviceControl
{
    public class AnalogDeviceFactory : DeviceFactory
    {
        public override Device CreateDevice()
        {
            var device = new DefaultDevice();
            var analogDevice = new AnalogDevice(device);
            
            return analogDevice;
        }
    }
}