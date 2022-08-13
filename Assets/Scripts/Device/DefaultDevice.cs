namespace DeviceControl
{
    public class DefaultDevice : Device
    {
        public override Command GetCommand<T>()
        {
            foreach (var command in availableCommands)
            {
                if (command.GetType() == typeof(T))
                    return command;
            }

            return null;
        }
    }
}