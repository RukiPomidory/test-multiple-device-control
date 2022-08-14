namespace DeviceControl
{
    public class ForceCollisionHandlerFactory : ICollisionHandlerFactory
    {
        public ICollisionHandler Create()
        {
            return new ForceCollisionHandler();
        }
    }
}