namespace DeviceControl
{
    public class SmoothCommandFactory : ICommandFactory
    {
        public Command Create(Device device)
        {
            return new SmoothCommand(device);
        }
    }
}