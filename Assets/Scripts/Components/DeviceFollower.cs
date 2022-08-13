using System;
using UnityEngine;

namespace DeviceControl.Components
{
    public class DeviceFollower : MonoBehaviour
    {
        public Device Device;

        private void Update()
        {
            if (Device != null)
                transform.position = Device.Position;
        }
    }
}