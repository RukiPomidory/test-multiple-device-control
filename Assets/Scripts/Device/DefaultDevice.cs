using System.Collections.Generic;
using System.Linq;

namespace DeviceControl
{
    public class DefaultDevice : Device
    {
        public override string Name { get; set; }
        public override Command CurrentCommand => currentCommand;

        protected List<Command> availableCommands = new();

        protected Command currentCommand;
        
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
            command.SubscribeOnStart(() => currentCommand = command);
            command.SubscribeOnFinish(() => currentCommand = null);
            
            availableCommands.Add(command);
        }

        public override List<Command> GetAvailableCommands()
        {
            return availableCommands.ToList();
        }
    }
}