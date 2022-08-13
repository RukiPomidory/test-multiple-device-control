namespace DeviceControl
{
    public interface IDeviceFactory
    {
        Device CreateDevice();

        Device CreateDevice(string name);
    }
}