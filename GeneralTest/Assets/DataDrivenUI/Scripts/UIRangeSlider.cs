using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasData
{
    public class UIRangeSlider : MonoBehaviour
    {
        [SerializeField]
        private Text valueText;

        public void ValueCheck(Slider slider)
        {
            valueText.text = (slider.value).ToString();
        }
    }
}