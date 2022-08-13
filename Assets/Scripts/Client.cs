using System;
using UnityEngine;

namespace DeviceControl
{
    public class Client : MonoBehaviour
    {
        public GameObject deviceVisualPrefab;
        public Transform devicesParent;
        
        private DeviceControlFacade deviceControl;
        
        private void Start()
        {
            deviceControl = CreateDeviceFacade();

             var device = deviceControl.CreateDevice<DiscreteDevice>();
             var device2 = deviceControl.CreateDevice<AnalogDevice>();
             var device3 = deviceControl.CreateDevice<CombinedDevice>();
            
             var command = device.GetCommand<InstantCommand>();
            
             command.Execute(new Vector3(5, 5, 9));
            
            deviceControl.Save();
            
            deviceControl.Load();
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