namespace DeviceControl
{
    public class DeviceControlFacade
    {
        private IDeviceControlOperator deviceOperator;
        private IDeviceControlSerializer serializer;
        private IDeviceControlVisualizer visualizer;

        private DiscreteDeviceFactory discreteFactory;
        private AnalogDeviceFactory analogFactory;
        private CombinedDeviceFactory combinedFactory;
        
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
            var memento = serializer.Load();
            deviceOperator.RestoreState(memento);
        }

        public void AddDiscreteDevice()
        {
            CreateAndAddDevice(discreteFactory);
        }

        public void AddAnalogDevice()
        {
            CreateAndAddDevice(analogFactory);
        }
        
        public void AddCombinedDevice()
        {
            CreateAndAddDevice(combinedFactory);
        }

        private void CreateAndAddDevice(IDeviceFactory factory)
        {
            var device = factory.CreateDevice();
            deviceOperator.AddDevice(device);
        }
    }
}