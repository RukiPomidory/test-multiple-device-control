using System;
using System.Collections.Generic;

namespace DeviceControl
{
    public interface IDeviceControlOperator
    {
        Device CreateDevice<T>() where T : Device;
        Device CreateDevice(Type type);
        
        List<Device> GetDevices();

        List<Type> GetSupportedDeviceTypes();
        
        DeviceControlMemento SaveState();
        void RestoreState(DeviceControlMemento memento);
    }
}