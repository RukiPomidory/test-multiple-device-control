namespace DeviceControl
{
    public interface IDeviceControlSerializer
    {
        void Save(DeviceControlMemento memento);
        DeviceControlMemento Load();

        void SpecifySavePath(string savePath);
    }
}