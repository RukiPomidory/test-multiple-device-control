using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeviceControl
{
    [Serializable]
    public class DeviceControlMemento
    {
        public List<DeviceMemento> Devices => devices;
        
        [SerializeField]
        private List<DeviceMemento> devices;

        public DeviceControlMemento(List<DeviceMemento> devices)
        {
            this.devices = devices;
        }
    }
}