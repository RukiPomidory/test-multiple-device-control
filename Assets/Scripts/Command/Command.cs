using System;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Command
    {
        protected Action OnStarted;
        protected Action OnFinish;

        protected Device device;
        protected ICollisionHandler collisionHandler;

        public Command()
        {
            var factory = new ExceptionCollisionHandlerFactory();
            
            SetCollisionHandler(factory.Create());
        }

        public void SetCollisionHandler(ICollisionHandler handler)
        {
            collisionHandler = handler;
        }

        public virtual void SubscribeOnStart(Action handler)
        {
            OnStarted += handler;
        }

        public virtual void SubscribeOnFinish(Action handler)
        {
            OnFinish += handler;
        }

        public virtual void SubscribeOnFinishOnce(Action handler)
        {
            void ExecutedOnce()
            {
                OnFinish -= ExecutedOnce;
                handler?.Invoke();
            }

            OnFinish += ExecutedOnce;
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