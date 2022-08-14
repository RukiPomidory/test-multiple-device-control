namespace DeviceControl
{
    public class ExceptionCollisionHandlerFactory : ICollisionHandlerFactory
    {
        public ICollisionHandler Create()
        {
            return new ExceptionCollisionHandler();
        }
    }
}