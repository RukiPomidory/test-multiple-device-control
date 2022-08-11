namespace DeviceControl
{
    public class DiscreteDeviceFactory : IDeviceFactory
    {
        public Device CreateDevice()
        {
            var device = new DefaultDevice();
            var discreteDevice = new DiscreteDevice(device);
            
            return discreteDevice;
        }
    }
}