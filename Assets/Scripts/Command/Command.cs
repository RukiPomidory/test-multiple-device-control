using System;
using UnityEngine;

namespace DeviceControl
{
    public abstract class Command
    {
        public Action OnFinish;
        
        public abstract void Execute(Vector3 target);
        public abstract void Stop();
    }
}