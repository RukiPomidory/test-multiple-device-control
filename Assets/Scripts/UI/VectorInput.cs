using System.Globalization;
using TMPro;
using UnityEngine;

namespace DeviceControl.UI
{
    public class VectorInput : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField inputX;
        [SerializeField]
        private TMP_InputField inputY;
        [SerializeField]
        private TMP_InputField inputZ;
    
        public Vector3 Value
        {
            get
            {
                float x = float.Parse(inputX.text);
                float y = float.Parse(inputY.text);
                float z = float.Parse(inputZ.text);

                Vector3 vector = new Vector3(x, y, z);

                return vector;
            }

            set
            {
                inputX.text = value.x.ToString(CultureInfo.InvariantCulture);
                inputY.text = value.y.ToString(CultureInfo.InvariantCulture);
                inputZ.text = value.z.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
