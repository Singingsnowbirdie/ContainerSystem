using ItemSystem;
using UI.ReactiveViews;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class ItemUIView : UIReactiveView<ItemUIModel>, IPointerEnterHandler
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _selectionIndicationImg;
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

            uiModel.SelectedItemID
                .Subscribe(val => OnSelectedItemUpdated(val))
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

        // INTERACTING
        private void OnButtonPressed()
        {
            if (uiModel.InteractedItemID.Value == null)
                uiModel.InteractedItemID.Value = uiModel.UniqueID;
        }

        // SELECTION
        #region
        public void OnPointerEnter(PointerEventData eventData)
        {
            uiModel.SelectedItemID.Value = uiModel.UniqueID;
        }

        private void OnSelectedItemUpdated(string selectedItemID)
        {
            UIModel.IsSelected.Value = selectedItemID == uiModel.UniqueID;
        }

        private void OnItemSelected(bool isSelected)
        {
            _selectionIndicationImg.SetActive(isSelected);
        }
        #endregion

        // FILTERING
        #region
        private void OnFiltered(EContainerFilter filter)
        {
            _equipmentClassTF.gameObject.SetActive(IsEquipmentFiltered(filter));
            gameObject.SetActive(FitsToFilter(filter));
        }

        public bool FitsToFilter(EContainerFilter filter)
        {
            if (filter == EContainerFilter.All)
                return true;

            return UIModel.SuitableFilters.Contains(filter);
        }

        private bool IsEquipmentFiltered(EContainerFilter filter)
        {
            return filter switch
            {
                EContainerFilter.Weapons or EContainerFilter.Armor => true,
                _ => false,
            };
        }
        #endregion
    }
}
