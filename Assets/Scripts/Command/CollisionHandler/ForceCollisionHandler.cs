using System;

namespace DeviceControl
{
    public class ForceCollisionHandler : ICollisionHandler
    {
        public void Handle(Command current, Action runRequestedCommand)
        {
            current.Stop();
            runRequestedCommand();
        }
    }
}