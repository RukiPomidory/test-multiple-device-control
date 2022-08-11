using System.Collections.Generic;
using DeviceControl;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Device
    {
        public Vector3 State { get; protected set; }

        protected List<Command> availableCommands = new();

        public void SetState(Vector3 state)
        {
            State = state;
        }

        public void AddCommand(Command command)
        {
            availableCommands.Add(command);
        }
        
        public DeviceMemento SaveState()
        {
            return new DeviceMemento(State);
        }

        public void RestoreState(DeviceMemento memento)
        {
            State = memento.State;
        }
    }
}
