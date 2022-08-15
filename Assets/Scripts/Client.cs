using System;
using DeviceControl.UI;
using UnityEngine;

namespace DeviceControl
{
    public class Client : MonoBehaviour
    {
        [SerializeField]
        private MenuController menuController;
        
        [SerializeField]
        private DeviceConstructorController deviceConstructor;
        
        [SerializeField]
        private GameObject deviceVisualPrefab;
        
        [SerializeField]
        private Transform devicesParent;
        
        private DeviceControlFacade deviceControl;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            deviceControl = CreateDeviceFacade();
            
            deviceConstructor.OnReady += CreateDeviceRequestHandler;

            foreach (var type in deviceControl.GetSupportedTypes())
            {
                deviceConstructor.AddType(type);
            }

            deviceControl.Load();
        }

        private void CreateDeviceRequestHandler()
        {
            AddDevice(deviceConstructor.DeviceType, deviceConstructor.DeviceName);
        }

        private void AddDevice<T>(string deviceName) where T : Device
        {
            AddDevice(typeof(T), deviceName);
        }
        
        private void AddDevice(Type type, string deviceName)
        {
            var device = deviceControl.CreateDevice(type);
            device.Name = deviceName;
            menuController.AddMenuElement(device);
        }

        private DeviceControlFacade CreateDeviceFacade()
        {
            var deviceOperator = new DeviceControlOperator();
            var serializer = new DeviceControlSerializer();
            var visualizer = new DeviceControlVisualizer();

            serializer.SpecifySavePath(@"D:\test.json");
            
            visualizer.SetPrefab(deviceVisualPrefab);
            visualizer.SetParent(devicesParent);
            
            return new DeviceControlFacade(deviceOperator, serializer, visualizer);
        }
    }
}