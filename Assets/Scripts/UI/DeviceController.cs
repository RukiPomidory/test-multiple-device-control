using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeviceControl.UI
{
    public class DeviceController : MonoBehaviour
    {
        [SerializeField]
        private Transform commandParent;

        [SerializeField]
        private GameObject commandPrefab;

        private Device device;

        public void SetDevice(Device device)
        {
            this.device = device;
            
            ClearCommands();
            var commands = device.GetAvailableCommands();

            foreach (var command in commands)
            {
                AddCommand(command);
            }
        }

        private void Awake()
        {
            ClearCommands();
        }

        private void ClearCommands()
        {
            foreach (Transform child in commandParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void AddCommand(Command command)
        {
            var commandControllerObject = Instantiate(commandPrefab, commandParent);
            var commandController = commandControllerObject.GetComponent<DeviceCommandController>();
            commandController.SetCommand(command);
        }
    }
}
