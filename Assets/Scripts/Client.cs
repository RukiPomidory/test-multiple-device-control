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
        private GameObject deviceVisualPrefab;
        [SerializeField]
        private Transform devicesParent;
        
        private DeviceControlFacade deviceControl;

        public void AddDeviceTest()
        {
            AddDevice<CombinedDevice>();
        }
        
        private void Start()
        {
            deviceControl = CreateDeviceFacade();
            deviceControl.Load();
        }

        private void AddDevice<T>() where T : Device
        {
            var device = deviceControl.CreateDevice<T>();
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