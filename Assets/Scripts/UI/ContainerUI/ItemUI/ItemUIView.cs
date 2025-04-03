using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemUIView : UIReactiveView<ItemUIModel>
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private Image _selectionIndicationImg;
        [SerializeField] private ItemTypeIconView _itemIcon;
        [SerializeField] private TextMeshProReactiveStringView _itemNameTF;
        [SerializeField] private TextMeshProReactiveFloat _itemWeightTF;

        public ItemUIModel UIModel { get; private set; }

        protected override void OnSetModel(ItemUIModel uiModel)
        {
            UIModel = uiModel;
            UpdateToggleVisuals(_toggle.isOn);

            _toggle.OnValueChangedAsObservable()
                .Subscribe(isOn => OnItemSelected(isOn))
                .AddTo(this);

            UIModel.IsSelected
                .Subscribe(isSelected =>
                {
                    _toggle.isOn = isSelected;
                    UpdateToggleVisuals(isSelected);
                })
                .AddTo(this);

            _itemIcon.SetUIModel(uiModel.ItemTypeIcon);
            _itemNameTF.SetUIModel(uiModel.ItemName);
        }

        private void OnItemSelected(bool isOn)
        {
            UpdateToggleVisuals(isOn);
            UIModel.IsSelected.Value = isOn;
        }

        private void UpdateToggleVisuals(bool isOn)
        {
            if (_selectionIndicationImg != null)
            {
                _selectionIndicationImg.enabled = isOn;
            }
        }
    }
}

