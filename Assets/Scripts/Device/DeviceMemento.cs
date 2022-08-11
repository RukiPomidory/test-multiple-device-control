using UnityEngine;

namespace DeviceControl
{
    public class DeviceMemento
    {
        public Vector3 State { get; }

        public DeviceMemento(Vector3 state)
        {
            State = state;
        }
    }
}