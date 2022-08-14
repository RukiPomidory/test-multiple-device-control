using System;

namespace DeviceControl
{
    public class SequenceCollisionHandler : ICollisionHandler
    {
        public void Handle(Command current, Action runRequestedCommand)
        {
            current.SubscribeOnFinish(runRequestedCommand);
        }
    }
}