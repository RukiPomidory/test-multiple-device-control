using System.Collections.Generic;
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
            ValidatePath(savePath);
            
            var json = JsonUtility.ToJson(memento, true);
            File.WriteAllText(savePath, json);
        }

        public DeviceControlMemento Load()
        {
            if (!File.Exists(savePath))
                return new DeviceControlMemento(new List<DeviceMemento>());
            
            var json = File.ReadAllText(savePath);
            var memento = JsonUtility.FromJson<DeviceControlMemento>(json);

            return memento;
        }

        public void SpecifySavePath(string savePath)
        {
            this.savePath = savePath;
        }

        private void ValidatePath(string path)
        {
            if (File.Exists(path))
                return;

            var directory = Path.GetDirectoryName(path);

            if (directory != null)
                Directory.CreateDirectory(directory);
        }
    }
}