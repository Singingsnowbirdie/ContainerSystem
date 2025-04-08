using ItemSystem;
using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemUIView : UIReactiveView<ItemUIModel>
    {
        [SerializeField] private Button _button;
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

            _button.OnClickAsObservable()
                .Subscribe(_ => OnButtonPressed())
                .AddTo(this);

            UIModel.IsSelected
                .Subscribe(val => OnItemSelected(val))
                .AddTo(this);

            uiModel.SelectedFilter
                .Subscribe(filter => OnFiltered(filter))
                .AddTo(this);

            _itemIcon.SetUIModel(uiModel.ItemTypeIcon);
            _itemNameTF.SetUIModel(uiModel.ItemName);
            _itemWeightTF.SetUIModel(uiModel.ItemWeight);
            _itemCostTF.SetUIModel(uiModel.ItemCost);
            _itemTypeTF.SetUIModel(uiModel.ItemType);

            if (!string.IsNullOrEmpty(uiModel.EquipmentClass.Value))
                _equipmentClassTF.SetUIModel(uiModel.EquipmentClass);
        }

        private void OnButtonPressed()
        {
            // TODO: If equip mode is active, equip or consume
            uiModel.IsSelected.Value = true;
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

        private void OnItemSelected(bool isSelected)
        {
            _selectionIndicationImg.enabled = isSelected;

            if (isSelected)
            {
                UIModel.ContainerUIModel.SelectedItemID.Value = UIModel.UniqueID;
            }
        }
    }
}
