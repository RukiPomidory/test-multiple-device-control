namespace DeviceControl
{
    public interface ICommandFactory
    {
        Command Create(Device device);
    }
}