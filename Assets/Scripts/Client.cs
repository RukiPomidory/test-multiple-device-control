using System;
using UnityEngine;

namespace DeviceControl
{
    public class Client : MonoBehaviour
    {
        private DeviceControlFacade deviceControl;
        
        private void Start()
        {
            deviceControl = CreateDeviceFacade();
        }

        private DeviceControlFacade CreateDeviceFacade()
        {
            var deviceOperator = new DeviceControlOperator();
            var serializer = new DeviceControlSerializer();
            var visualizer = new DeviceControlVisualizer();

            return new DeviceControlFacade(deviceOperator, serializer, visualizer);
        }
    }
}