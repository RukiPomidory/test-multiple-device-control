using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DeviceControl.Components;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DeviceControl
{
    public class DeviceControlVisualizer : IDeviceControlVisualizer
    {
        private Dictionary<Device, GameObject> objects = new();
        private GameObject prefab;
        private Transform parent;

        public void SetPrefab(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public void SetParent(Transform parent)
        {
            this.parent = parent;
        }
        
        public void Create(Device device)
        {
            var gameObject = CreateGameObject();

            var component = gameObject.AddComponent<DeviceFollower>();
            component.Device = device;
            
            objects.Add(device, gameObject);
        }

        public void CreateRange(IEnumerable<Device> devices)
        {
            foreach (var device in devices)
            {
                Create(device);
            }
        }

        public void Remove(Device device)
        {
            var gameObject = objects[device];
            
            if (Application.isPlaying)
            {
                Object.Destroy(gameObject);
            }
            else
            {
                Object.DestroyImmediate(gameObject);
            }
            
            objects.Remove(device);
        }

        public void RemoveAll()
        {
            var keys = objects.Keys.ToList();
            foreach (var device in keys)
            {
                Remove(device);
            }
        }

        private GameObject CreateGameObject()
        {
            if (!prefab)
            {
                return new GameObject();
            }
            
            return Object.Instantiate(prefab, parent);
        }
    }
}