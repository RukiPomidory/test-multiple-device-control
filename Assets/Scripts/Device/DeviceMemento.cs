using System;
using UnityEngine;

namespace DeviceControl
{
    [Serializable]
    public class DeviceMemento
    {
        public Vector3 Position => position;
        public Type Type => ToType(type);
        public string Name => name;
        
        [SerializeField]
        private Vector3 position;
        [SerializeField]
        private string type;
        [SerializeField]
        private string name;

        public DeviceMemento(Vector3 position, Type type, string name)
        {
            this.position = position;
            this.type = ToString(type);
            this.name = name;
        }

        private string ToString(Type type)
        {
            return type.FullName;
        }

        private Type ToType(string type)
        {
            return Type.GetType(type);
        }
    }
}