using ContainerSystem;
using DataSystem;
using ItemSystem;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using VContainer;
using VContainer.Unity;

namespace UI
{
    public class ContainerUIPresenter : IStartable
    {
        // This UI
        [Inject] private readonly ContainerUIModel _containerUIModel;
        [Inject] private readonly ContainerUIView _containerUIView;

        // Other
        [Inject] private readonly ContainersModel _containersModel;
        [Inject] private readonly LocalizationModel _localizationModel;

        private ContainerUILocalizationHandler _localizationHandler = new ContainerUILocalizationHandler();

        public void Start()
        {
            _containerUIView.OnSetModel(_containerUIModel);

            _containerUIModel.OpenContainerUI
                .Subscribe(OpenContainerUI)
                .AddTo(_containerUIView);

            _containerUIModel.IsContainerUIOpen
                .Subscribe(val => _containerUIView.ShowContainerUI(val))
                .AddTo(_containerUIView);

            _containerUIModel.SelectedItemID
                .Subscribe(val => OnItemSelected(val))
                .AddTo(_containerUIView);

            _containerUIModel.SortingButtonsAreaModel.SortingType
                .Subscribe(val => OnSortingTypeUpdated(val))
                .AddTo(_containerUIView);

            _localizationHandler.Localize(_localizationModel, _containerUIModel, _containerUIView);
        }

        private void OnSortingTypeUpdated(ESortingType sortingType)
        {
            switch (sortingType)
            {
                case ESortingType.NameUp:
                    SortByName(false);
                    break;
                case ESortingType.NameDown:
                    SortByName(true);
                    break;

                case ESortingType.TypeUp:
                    SortByType(false);
                    break;
                case ESortingType.TypeDown:
                    SortByType(true);
                    break;

                case ESortingType.WeightUp:
                    SortByWeight(false);
                    break;
                case ESortingType.WeightDown:
                    SortByWeight(true);
                    break;

                case ESortingType.CostUp:
                    SortByCost(false);
                    break;
                case ESortingType.CostDown:
                    SortByCost(true);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(sortingType), sortingType, "Unknown sorting type");
            }
        }

        private void SortByName(bool isDescending)
        {
            var comparer = isDescending
                ? Comparer<ItemUIModel>.Create((x, y) => -string.Compare(x.ItemName.Value, y.ItemName.Value, StringComparison.OrdinalIgnoreCase))
                : Comparer<ItemUIModel>.Create((x, y) => string.Compare(x.ItemName.Value, y.ItemName.Value, StringComparison.OrdinalIgnoreCase));

            SortCollection(comparer);
        }

        private void SortByType(bool isDescending)
        {
            var comparer = isDescending
                ? Comparer<ItemUIModel>.Create((x, y) => -string.Compare(x.ItemType.Value.ToString(), y.ItemType.Value.ToString(), StringComparison.OrdinalIgnoreCase))
                : Comparer<ItemUIModel>.Create((x, y) => string.Compare(x.ItemType.Value.ToString(), y.ItemType.Value.ToString(), StringComparison.OrdinalIgnoreCase));

            SortCollection(comparer);
        }

        private void SortByWeight(bool isDescending)
        {
            var comparer = isDescending
                ? Comparer<ItemUIModel>.Create((x, y) => -x.ItemWeight.Value.CompareTo(y.ItemWeight.Value))
                : Comparer<ItemUIModel>.Create((x, y) => x.ItemWeight.Value.CompareTo(y.ItemWeight.Value));

            SortCollection(comparer);
        }

        private void SortByCost(bool isDescending)
        {
            var comparer = isDescending
                ? Comparer<ItemUIModel>.Create((x, y) => -x.ItemCost.Value.CompareTo(y.ItemCost.Value))
                : Comparer<ItemUIModel>.Create((x, y) => x.ItemCost.Value.CompareTo(y.ItemCost.Value));

            SortCollection(comparer);
        }

        private void SortCollection(IComparer<ItemUIModel> comparer)
        {
            var itemsList = _containerUIModel.Items.ToList();
            itemsList.Sort(comparer);

            _containerUIModel.Items.Clear();
            foreach (var item in itemsList)
            {
                _containerUIModel.Items.Add(item);
            }
        }

        private void OnItemSelected(string selecteditemID)
        {
            if (string.IsNullOrEmpty(selecteditemID))
                return;

            foreach (ItemUIModel item in _containerUIModel.Items)
            {
                if (item.UniqueID != selecteditemID &&
                    item.IsSelected.Value)
                {
                    item.IsSelected.Value = false;
                }
            }
        }

        private void OpenContainerUI(ContainerData data)
        {
            _containerUIModel.Items.Clear();

            foreach (ItemData itemData in data.Items)
            {
                if (_containersModel.ItemDatabase.TryGetConfig(itemData.ItemConfigKey, out ItemConfig itemConfig))
                {
                    string itemName = GetItemName(itemConfig);
                    string itemType = GetItemType(itemConfig);
                    int itemCost = GetItemCost(itemConfig);
                    string equipmentClass = GetEquipmentClass(itemConfig);

                    ItemUIModel uiModel = new(itemData, itemConfig, itemName, itemCost, itemType, equipmentClass, _containerUIModel);
                    _containerUIModel.Items.Add(uiModel);
                }
            }

            _containerUIModel.SortingButtonsAreaModel.SortingType.Value = ESortingType.NameUp;

            if (_containerUIModel.Items.Count > 0)
                _containerUIModel.Items[0].IsSelected.Value = true;
        }

        private string GetItemType(ItemConfig itemConfig)
        {
            if (_localizationModel.TryGetTranslation(ELocalizationRegion.ItemType, itemConfig.ItemType.ToString(), out string translation))
            {
                return translation;
            }
            return itemConfig.ItemType.ToString();
        }

        private string GetEquipmentClass(ItemConfig itemConfig)
        {
            if (itemConfig is EquipmentConfig equipmentConfig &&
                _localizationModel.TryGetTranslation(ELocalizationRegion.EquipmentClass, equipmentConfig.EquipmentClass.ToString(), out string translation))
            {
                return translation;
            }
            return null;
        }

        private int GetItemCost(ItemConfig itemConfig)
        {
            // TODO: When you sell or buy an item, its base value will change.

            return itemConfig.BasicСost;
        }

        private string GetItemName(ItemConfig itemConfig)
        {
            if (_localizationModel.TryGetTranslation(itemConfig.LocalizationRegion, itemConfig.ItemConfigKey, out string translation))
            {
                return translation;
            }

            return itemConfig.ItemDefaultName;
        }
    }
}
