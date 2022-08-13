using System.Collections.Generic;
using System.Linq;

namespace DeviceControl
{
    public class DefaultDevice : Device
    {
        public override string Name { get; set; }
        
        protected List<Command> availableCommands = new();
        
        public override Command GetCommand<T>()
        {
            foreach (var command in availableCommands)
            {
                if (command.GetType() == typeof(T))
                    return command;
            }

            return null;
        }

        public override void AddCommand(Command command)
        {
            availableCommands.Add(command);
        }

        public override List<Command> GetAvailableCommands()
        {
            return availableCommands.ToList();
        }
    }
}