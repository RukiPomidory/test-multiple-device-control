using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DeviceControl
{
    public class SmoothCommand : Command
    {
        private Device device;
        private Task transition;

        public float Duration { get; protected set; }

        public SmoothCommand(Device device)
        {
            this.device = device;
        }
        
        public override void Execute(Vector3 target)
        {
            throw new NotImplementedException();
        }

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}