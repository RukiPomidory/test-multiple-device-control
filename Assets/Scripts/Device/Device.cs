using System.Collections.Generic;
using System.Linq;
using DeviceControl;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Device
    {
        public abstract string Name { get; set; }
        public abstract Command CurrentCommand { get; }

        public virtual Vector3 Position { get; protected set; }


        public abstract Command GetCommand<T>() where T : Command;
        
        public virtual void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public abstract void AddCommand(Command command);

        public abstract List<Command> GetAvailableCommands();
        
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
