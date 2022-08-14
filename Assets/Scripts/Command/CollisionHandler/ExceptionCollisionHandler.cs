using System;

namespace DeviceControl
{
    public class ExceptionCollisionHandler : ICollisionHandler
    {
        public void Handle(Command current, Action runRequestedCommand)
        {
            throw new InvalidOperationException();
        }
    }
}