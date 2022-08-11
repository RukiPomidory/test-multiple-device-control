using UnityEngine;

namespace DeviceControl
{
    public class DeviceMemento
    {
        public Vector3 Position { get; }

        public DeviceMemento(Vector3 position)
        {
            Position = position;
        }
    }
}