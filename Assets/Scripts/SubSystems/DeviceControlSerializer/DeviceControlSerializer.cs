using System.IO;
using UnityEngine;
using UnityEngine.WSA;

namespace DeviceControl
{
    public class DeviceControlSerializer : IDeviceControlSerializer
    {
        private string savePath;
        
        public void Save(DeviceControlMemento memento)
        {
            var json = JsonUtility.ToJson(memento, true);
            File.WriteAllText(savePath, json);
        }

        public DeviceControlMemento Load()
        {
            var json = File.ReadAllText(savePath);
            var memento = JsonUtility.FromJson<DeviceControlMemento>(json);

            return memento;
        }

        public void SpecifySavePath(string savePath)
        {
            this.savePath = savePath;
        }
    }
}