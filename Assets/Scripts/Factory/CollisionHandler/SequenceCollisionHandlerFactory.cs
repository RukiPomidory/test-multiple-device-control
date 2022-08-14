namespace DeviceControl
{
    public class SequenceCollisionHandlerFactory : ICollisionHandlerFactory
    {
        public ICollisionHandler Create()
        {
            return new SequenceCollisionHandler();
        }
    }
}