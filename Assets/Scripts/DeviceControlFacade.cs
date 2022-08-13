using System.Collections.Generic;

namespace DeviceControl
{
    public class DeviceControlFacade
    {
        private IDeviceControlOperator deviceOperator;
        private IDeviceControlSerializer serializer;
        private IDeviceControlVisualizer visualizer;
        
        public DeviceControlFacade(IDeviceControlOperator deviceOperator, IDeviceControlSerializer serializer, IDeviceControlVisualizer visualizer)
        {
            this.deviceOperator = deviceOperator;
            this.serializer = serializer;
            this.visualizer = visualizer;
        }

        public void Save()
        {
            var memento = deviceOperator.SaveState();
            serializer.Save(memento);
        }

        public void Load()
        {
            visualizer.RemoveAll();
            
            var memento = serializer.Load();
            deviceOperator.RestoreState(memento);
            
            visualizer.CreateRange(GetAllDevices());
        }

        public Device CreateDevice<T>() where T : Device
        {
            var device = deviceOperator.CreateDevice<T>();
            visualizer.Create(device);
            
            return device;
        }

        public List<Device> GetAllDevices()
        {
            return deviceOperator.GetDevices();
        }
    }
}