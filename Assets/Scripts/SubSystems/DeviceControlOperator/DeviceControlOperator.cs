using System.Collections.Generic;

namespace DeviceControl
{
    public class DeviceControlOperator : IDeviceControlOperator
    {
        private List<Device> devices;
        
        
        public void AddDevice(Device device)
        {
            throw new System.NotImplementedException();
        }

        public List<Device> GetDevices()
        {
            throw new System.NotImplementedException();
        }

        public DeviceControlMemento SaveState()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreState(DeviceControlMemento memento)
        {
            throw new System.NotImplementedException();
        }
    }
}