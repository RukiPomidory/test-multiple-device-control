using System.Collections.Generic;

namespace DeviceControl
{
    public abstract class DeviceDecorator : Device
    {
        protected Device device;

        public DeviceDecorator(Device device)
        {
            this.device = device;
        }

        public override void AddCommand(Command command)
        {
            device.AddCommand(command);
        }

        public override List<Command> GetAvailableCommands()
        {
            return device.GetAvailableCommands();
        }
    }
}