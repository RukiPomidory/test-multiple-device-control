using System.Collections.Generic;
using UnityEngine;

namespace DeviceControl
{
    public abstract class DeviceDecorator : Device
    {
        public override Vector3 Position => device.Position;

        protected Device device;
        
        public DeviceDecorator(Device device)
        {
            this.device = device;
        }

        public override void SetPosition(Vector3 position)
        {
            device.SetPosition(position);
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