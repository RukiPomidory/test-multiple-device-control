using System;
using UnityEngine;

namespace DeviceControl.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject deviceElementPrefab;

        [SerializeField]
        private GameObject addButton;
        
        public void AddMenuElement(Device device)
        {
            CreateElement(device);
            MoveAddButtonDown();
        }
        
        private void CreateElement(Device device)
        {
            var element = Instantiate(deviceElementPrefab, transform);
            var deviceController = element.GetComponent<DeviceController>();
            deviceController.SetDevice(device);
        }

        private void MoveAddButtonDown()
        {
            if (!addButton)
            {
                Debug.LogError("Can't move button because there is no button");
                return;
            }
        
            var count = transform.childCount;
            addButton.transform.SetSiblingIndex(count);
        }
    }
}
