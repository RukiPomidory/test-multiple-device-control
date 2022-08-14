using System;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Command
    {
        public Action OnStarted;
        public Action OnFinish;

        protected Device device;
        protected ICollisionHandler collisionHandler;

        public Command()
        {
            var factory = new ExceptionCollisionHandlerFactory();
            collisionHandler = factory.Create();
        }

        public void SetCollisionHandler(ICollisionHandler handler)
        {
            collisionHandler = handler;
        }
        
        public void Execute(Vector3 target)
        {
            if (device.CurrentCommand == null)
            {
                Process(target);
                return;
            }

            collisionHandler.Handle(device.CurrentCommand, () => Execute(target));
        }
        
        public abstract void Stop();

        protected abstract void Process(Vector3 target);
    }
}