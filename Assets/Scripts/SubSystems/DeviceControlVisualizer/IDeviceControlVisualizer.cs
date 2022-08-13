using System.Collections.Generic;

namespace DeviceControl
{
    public interface IDeviceControlVisualizer
    {
        void Create(Device device);
        void CreateRange(IEnumerable<Device> devices);
        void Remove(Device device);
        void RemoveAll();
    }
}