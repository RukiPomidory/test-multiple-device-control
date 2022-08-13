using System.Collections.Generic;

namespace DeviceControl
{
    public interface IDeviceControlOperator
    {
        void AddDevice(Device device);
        List<Device> GetDevices();
        
        DeviceControlMemento SaveState();
        void RestoreState(DeviceControlMemento memento);
    }
}