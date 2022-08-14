namespace DeviceControl
{
    public class InstantCommandFactory : ICommandFactory
    {
        public Command Create(Device device)
        {
            return new InstantCommand(device);
        }
    }
}