using System;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Command
    {
        public Action OnStarted;
        public Action OnFinish;

        protected Device device;
        protected CollisionHandler collisionHandler;

        public void Execute(Vector3 target)
        {
            if (device.CurrentCommand == null)
            {
                Process(target);
                return;
            }

            throw new NotImplementedException();
        }
        
        public abstract void Stop();

        protected abstract void Process(Vector3 target);
    }
}