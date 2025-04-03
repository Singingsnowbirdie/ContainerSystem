using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ReactiveViews
{
    public partial class EnumReactiveView<T> : UIReactiveView<EnumReactiveView<T>.UIViewEnumModel> where T : System.Enum
    {
        public class UIViewEnumModel
        {
            public UIViewEnumModel(ReactiveProperty<T> enumValue)
            {
                EnumValue = enumValue;
            }

            public ReactiveProperty<T> EnumValue { get; }
        }

        [SerializeField] private IconsMapSO<T> _iconMap;
        [SerializeField] private Image _icon;
        [SerializeField] private bool _isNativeSize = false;

        protected override void OnSetModel(UIViewEnumModel viewModel)
        {
            viewModel
                .EnumValue
                .Subscribe(val => SetActiveBaseOnEnumValue(val))
                .AddTo(compositeDisposable);
        }

        private void SetActiveBaseOnEnumValue(T enumValue)
        {
            try
            {
                if (_iconMap.IconMap.TryGetValue(enumValue, out var iconSprite))
                {
                    _icon.sprite = iconSprite;
                    _icon.color = _iconMap.ColorMap[enumValue];

                    if (_isNativeSize)
                    {
                        _icon.SetNativeSize();
                    }
                }
            }
            catch
            {
                Debug.LogError($"UIViewEnum: Icon Map missing {this.gameObject.transform.name}");
            }
        }

        public void SetUIModel(ReactiveProperty<T> enumValue)
        {
            SetUIModel(new UIViewEnumModel(enumValue));
        }

        public void SetUIModel(T enumValue)
        {
            SetUIModel(new ReactiveProperty<T>(enumValue));
        }
    }
}