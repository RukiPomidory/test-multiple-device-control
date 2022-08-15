using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeviceControl.UI
{
    public class DeviceTypeMenuElementController : MonoBehaviour
    {
        public Action OnSelected;
        
        [SerializeField]
        private TMP_Text typeName;
        
        [SerializeField]
        private Toggle toggle;

        public void SetGroup(ToggleGroup group)
        {
            toggle.group = group;
        }

        public void SetCommandName(string newName)
        {
            typeName.text = newName;
        }

        private void Awake()
        {
            toggle.onValueChanged.AddListener(ToggleValueChangedHandler);
        }

        private void ToggleValueChangedHandler(bool selected)
        {
            if (selected)
                OnSelected?.Invoke();
        }
    }
}
