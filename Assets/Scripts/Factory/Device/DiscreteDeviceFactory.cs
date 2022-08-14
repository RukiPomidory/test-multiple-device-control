namespace DeviceControl
{
    public class DiscreteDeviceFactory : DeviceFactory
    {
        public override Device CreateDevice()
        {
            var device = new DefaultDevice();
            var discreteDevice = new DiscreteDevice(device);
            
            return discreteDevice;
        }
    }
}