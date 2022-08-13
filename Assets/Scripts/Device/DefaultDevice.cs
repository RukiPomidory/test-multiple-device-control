namespace DeviceControl
{
    public class DefaultDevice : Device
    {
        public override string Name { get; set; }
        
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