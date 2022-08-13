using System.Collections.Generic;
using System.Linq;
using DeviceControl;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Device
    {
        public abstract string Name { get; set; }

        public virtual Vector3 Position { get; protected set; }

        protected List<Command> availableCommands = new();

        public abstract Command GetCommand<T>() where T : Command;
        
        public virtual void SetPosition(Vector3 position)
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
            return new DeviceMemento(Position, GetType(), Name);
        }

        public void RestoreState(DeviceMemento memento)
        {
            SetPosition(memento.Position);
            Name = memento.Name;
        }
    }
}
