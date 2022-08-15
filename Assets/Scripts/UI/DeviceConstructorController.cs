using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeviceControl.UI
{
    public class DeviceConstructorController : MonoBehaviour
    {
        public Action OnReady;

        public string DeviceName => deviceName;
        public Type DeviceType => deviceType;

        [SerializeField]
        private TMP_InputField nameInput;
        [SerializeField]
        private Button applyButton;
        [SerializeField]
        private Transform typeElementsParent;
        [SerializeField]
        private GameObject typeElementPrefab;
        [SerializeField]
        private ToggleGroup toggleGroup;

        private readonly string defaultName = "unnamed";
        private readonly Type defaultType = typeof(DefaultDevice);

        private List<Type> validTypes = new();
        
        private string deviceName;
        private Type deviceType;

        
        public void AddType(Type type)
        {
            var gameObject = Instantiate(typeElementPrefab, typeElementsParent);
            var controller = gameObject.GetComponent<DeviceTypeMenuElementController>();
            
            controller.SetGroup(toggleGroup);
            controller.SetCommandName(type.Name);
            controller.OnSelected += () => SetType(type);
            
            validTypes.Add(type);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetView();
        }

        public void SetName(string deviceName)
        {
            nameInput.SetTextWithoutNotify(deviceName);
            this.deviceName = deviceName;
        }

        public void SetType(Type type)
        {
            deviceType = type;

            applyButton.interactable = validTypes.Contains(type);
        }
        
        public void FinishConstruction()
        {
            OnReady?.Invoke();
            Hide();
        }

        private void ResetView()
        {
            SetName(defaultName);
            SetType(defaultType);
            toggleGroup.SetAllTogglesOff();
        }
    }
}
