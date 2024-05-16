#if !UNITY_2023_1_OR_NEWER

using UnityEngine;
using UnityEngine.UIElements;

namespace RosettaUI.UIToolkit.UnityInternalAccess
{
    public class ClampFreeSliderInt : SliderInt
    {
        public ClampFreeSliderInt()
        {
            clamped = false;
            SliderPatchUtility.FixDraggerInvalidPosition(this);

        }
        internal override float SliderNormalizeValue(int currentValue, int lowerValue, int higherValue)
            => Mathf.Clamp01(base.SliderNormalizeValue(currentValue, lowerValue, higherValue));
        
        public override bool showInputField
        {
            get => base.showInputField;
            set
            {
                base.showInputField = value;
                SliderPatchUtility.BlockTextFieldKeyDownEvent(this);
            }
        }
    }
}

#endif