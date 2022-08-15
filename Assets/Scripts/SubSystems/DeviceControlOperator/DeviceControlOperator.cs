using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceControl
{
    public class DeviceControlOperator : IDeviceControlOperator
    {
        private List<Device> devices = new();
        private Dictionary<Type, IDeviceFactory> factories = new()
        {
            {typeof(DiscreteDevice), new DiscreteDeviceFactory()},
            {typeof(AnalogDevice), new AnalogDeviceFactory()},
            {typeof(CombinedDevice), new CombinedDeviceFactory()},
        };

        public Device CreateDevice<T>() where T : Device
        {
            return CreateDevice(typeof(T));
        }

        public Device CreateDevice(Type type)
        {
            var factory = factories[type];
            
            var device = factory.CreateDevice();
            devices.Add(device);

            return device;
        }

        public List<Device> GetDevices()
        {
            return devices.ToList();
        }

        public List<Type> GetSupportedDeviceTypes()
        {
            return factories.Keys.ToList();
        }

        public DeviceControlMemento SaveState()
        {
            var deviceMementos = new List<DeviceMemento>();

            foreach (var device in devices)
            {
                deviceMementos.Add(device.SaveState());
            }
            
            return new DeviceControlMemento(deviceMementos);
        }

        public void RestoreState(DeviceControlMemento memento)
        {
            var deviceMementos = memento.Devices;
            devices.Clear();
            
            foreach (var deviceMemento in deviceMementos)
            {
                var device = CreateDevice(deviceMemento.Type);
                device.RestoreState(deviceMemento);
            }
        }
    }
}