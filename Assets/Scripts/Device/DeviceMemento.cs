using UnityEngine;

namespace DefaultNamespace
{
    public class DeviceMemento
    {
        public Vector3 State { get; private set; }

        public DeviceMemento(Vector3 state)
        {
            State = state;
        }
    }
}