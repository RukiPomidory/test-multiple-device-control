using System;
using System.Collections.Generic;
using System.IO;
using DeviceControl.UI;
using UnityEngine;

namespace DeviceControl
{
    public class Client : MonoBehaviour
    {
        private readonly string saveFile = "SavedDevices.json";
        
        [SerializeField]
        private MenuController menuController;
        
        [SerializeField]
        private DeviceConstructorController deviceConstructor;
        
        [SerializeField]
        private GameObject deviceVisualPrefab;
        
        [SerializeField]
        private Transform devicesParent;
        
        private DeviceControlFacade deviceControl;
        private string savePath;
        
        private void Start()
        {
            Init();
        }

        private void OnDestroy()
        {
            deviceControl.Save();
        }

        private void Init()
        {
            savePath = Path.Combine(Application.persistentDataPath, saveFile);
            deviceControl = CreateDeviceFacade();
            
            deviceConstructor.OnReady += CreateDeviceRequestHandler;

            foreach (var type in deviceControl.GetSupportedTypes())
            {
                deviceConstructor.AddType(type);
            }

            deviceControl.Load();
            FillMenuWithDevices(deviceControl.GetAllDevices());
        }

        private void FillMenuWithDevices(List<Device> devices)
        {
            foreach (var device in devices)
            {
                menuController.AddMenuElement(device);
            }
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

            serializer.SpecifySavePath(savePath);
            
            visualizer.SetPrefab(deviceVisualPrefab);
            visualizer.SetParent(devicesParent);
            
            return new DeviceControlFacade(deviceOperator, serializer, visualizer);
        }
    }
}