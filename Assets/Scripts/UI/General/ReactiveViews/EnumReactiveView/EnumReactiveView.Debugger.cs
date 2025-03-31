using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI.ReactiveViews
{
    public partial class EnumReactiveView<T>
    {
#if UNITY_EDITOR
        [SerializeField] private T _previewValue;

        private void OnValidate()
        {
            SetActiveBaseOnEnumValue(_previewValue);
        }

        private void Reset()
        {
            _icon = GetComponentInChildren<Image>();
            if (_iconMap != null && _icon != null)
                SetActiveBaseOnEnumValue(_previewValue);
        }
#endif
    }

}