using System;

namespace DeviceControl
{
    public interface ICollisionHandler
    {
        void Handle(Command current, Action runRequestedCommand);
    }
}