using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DeviceControl
{
    public class SmoothCommand : Command
    {
        private AnalogDevice device;
        private Task transition;

        public SmoothCommand(AnalogDevice device)
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