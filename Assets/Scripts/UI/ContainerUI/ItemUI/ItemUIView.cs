using ItemSystem;
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
        [SerializeField] private TextMeshProReactiveStringView _itemTypeTF;
        [SerializeField] private TextMeshProReactiveFloat _itemWeightTF;
        [SerializeField] private TextMeshProReactiveInt _itemCostTF;

        [Header("EQUIPMENT RELATED")]
        [SerializeField] private TextMeshProReactiveStringView _equipmentClassTF;

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

            uiModel.SelectedFilter
                .Subscribe(filter => OnFiltered(filter))
                .AddTo(this);


            _itemIcon.SetUIModel(uiModel.ItemTypeIcon);
            _itemNameTF.SetUIModel(uiModel.ItemName);
            _itemWeightTF.SetUIModel(uiModel.ItemWeight);
            _itemCostTF.SetUIModel(uiModel.ItemCost);
            _itemTypeTF.SetUIModel(uiModel.ItemTypeStr);

            if (!string.IsNullOrEmpty(uiModel.EquipmentClass.Value))
                _equipmentClassTF.SetUIModel(uiModel.EquipmentClass);
        }

        private void OnFiltered(EContainerFilter filter)
        {
            _equipmentClassTF.gameObject.SetActive(IsEquipmentFiltered(filter));
        }

        private bool IsEquipmentFiltered(EContainerFilter filter)
        {
            return filter switch
            {
                EContainerFilter.Weapons or EContainerFilter.Armor => true,
                _ => false,
            };
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
