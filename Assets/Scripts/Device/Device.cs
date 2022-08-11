using System.Collections.Generic;
using System.Linq;
using DeviceControl;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Device
    {
        public Vector3 Position { get; protected set; }

        protected List<Command> availableCommands = new();
        
        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public virtual void AddCommand(Command command)
        {
            availableCommands.Add(command);
        }

        public virtual List<Command> GetAvailableCommands()
        {
            return availableCommands.ToList();
        }
        
        public DeviceMemento SaveState()
        {
            return new DeviceMemento(Position);
        }

        public void RestoreState(DeviceMemento memento)
        {
            Position = memento.State;
        }
    }
}
