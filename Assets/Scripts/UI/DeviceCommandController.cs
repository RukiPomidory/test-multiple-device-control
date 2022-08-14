using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DeviceControl.UI
{
    public class DeviceCommandController : MonoBehaviour
    {
        private Dictionary<Type, string> commandNames = new()
        {
            {typeof(InstantCommand), "Execute instantly"},
            {typeof(SmoothCommand), "Execute smooth"},
        };
        
        [SerializeField]
        private VectorInput vectorInput;

        [SerializeField]
        private TMP_Text buttonName;

        private Command command;
        
        public void SetCommand(Command command)
        {
            buttonName.text = commandNames[command.GetType()];
            this.command = command;
        }
        
        public void ExecuteCommand()
        {
            command.Execute(vectorInput.Value);
        }
    }
}
