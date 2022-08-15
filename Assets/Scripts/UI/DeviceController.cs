using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DeviceControl.UI
{
    public class DeviceController : MonoBehaviour
    {
        [SerializeField]
        private Transform commandParent;

        [SerializeField]
        private GameObject commandPrefab;

        [SerializeField]
        private TMP_Text deviceName;
        
        [SerializeField]
        private VectorInput devicePosition;
        
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
            devicePosition.ReadOnly = true;
        }

        private void Update()
        {
            deviceName.text = device.Name;
            devicePosition.Value = device.Position;
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
