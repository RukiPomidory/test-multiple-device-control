namespace DeviceControl
{
    public class CombinedDeviceFactory : IDeviceFactory
    {
        public Device CreateDevice()
        {
            var device = new DefaultDevice();
            var discreteDevice = new DiscreteDevice(device);
            var combinedDevice = new AnalogDevice(discreteDevice);

            return combinedDevice;
        }
    }
}