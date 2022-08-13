using UnityEngine;

namespace DeviceControl
{
    public class DeviceMemento
    {
        //TODO сделать сохраняемым в json
        
        public Vector3 Position { get; }

        public DeviceMemento(Vector3 position)
        {
            Position = position;
        }
    }
}