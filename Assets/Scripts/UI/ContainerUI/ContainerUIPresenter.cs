using ContainerSystem;
using DataSystem;
using InventorySystem;
using ItemSystem;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UI.MainMenu;
using UniRx;
using Unity.VisualScripting;
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
        [Inject] private readonly UIInputHandler _menuInputHandler;
        [Inject] private readonly InventoryModel _inventoryModel;

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

            _containerUIModel.InteractedItemID
                .Subscribe(val => OnItemInteracted(val))
                .AddTo(_containerUIView);

            _containerUIModel.SortingButtonsAreaModel.SortingType
                .Subscribe(val => OnSortingTypeUpdated(val))
                .AddTo(_containerUIView);

            _menuInputHandler.OnCancelPressed
                .Subscribe(_ => OnCancelPressed())
                .AddTo(_containerUIView);

            _localizationHandler.Localize(_localizationModel, _containerUIModel, _containerUIView);
        }

        private void OpenContainerUI(ContainerData data)
        {
            _containerUIModel.ContainerID = data.ContainerID;

            // Show Items
            _containerUIModel.Items.Clear();

            foreach (ItemData itemData in data.Items)
            {
                if (_containersModel.ItemDatabase.TryGetConfig(itemData.ItemConfigKey, out ItemConfig itemConfig))
                {
                    ItemUIModel uiModel = new ItemUIModel
                    {
                        UniqueID = itemData.ItemID,
                        ItemConfig = itemConfig,
                        SelectedFilter = _containerUIModel.SelectedFilter,
                        SelectedItemID = _containerUIModel.SelectedItemID,
                        InteractedItemID = _containerUIModel.InteractedItemID,
                        ItemTypeIcon = new ReactiveProperty<EItemType>(itemConfig.ItemType),
                        ItemCost = new ReactiveProperty<int>(itemConfig.BasicCost),
                        ItemWeight = new ReactiveProperty<float>(itemConfig.Weight),
                        ItemName = new ReactiveProperty<string>(_localizationHandler.GetItemNameTranslation(itemConfig)),
                        ItemType = new ReactiveProperty<string>(_localizationHandler.GetItemTypeTranslation(itemConfig)),
                        EquipmentClass = new ReactiveProperty<string>(_localizationHandler.GetEquipmentClassTranslation(itemConfig))
                    };

                    _containerUIModel.Items.Add(uiModel);
                }
            }

            _containerUIModel.SortingButtonsAreaModel.SortingType.Value = ESortingType.NameUp;

            // Show Filters
            _containerUIModel.ItemFilters.Clear();
            _containerUIModel.ItemFilters.AddRange(CreateContainerFilters());
        }

        // SORTING RELATED
        #region SORTING
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
        #endregion

        // FILTERS RELATED
        #region FILTERS
        private List<ItemFilterUIModel> CreateContainerFilters()
        {
            var filtersList = new List<ItemFilterUIModel>();

            var filterTypes = Enum.GetValues(typeof(EContainerFilter))
                                  .Cast<EContainerFilter>()
                                  .Where(f => f != EContainerFilter.Favorites);

            foreach (var filterType in filterTypes)
            {
                ItemFilterUIModel filterModel = new ItemFilterUIModel(filterType);
                filterModel.SelectedFilter = _containerUIModel.SelectedFilter;
                filterModel.HasItemsOfThisType.Value = HasItemsOfThisType(filterModel.FilterType.Value);
                filtersList.Add(filterModel);
            }

            return filtersList;
        }

        private bool HasItemsOfThisType(EContainerFilter filterType)
        {
            foreach (var item in _containerUIModel.Items)
            {
                if (item.SuitableFilters.Contains(filterType))
                    return true;
            }

            return false;
        }

        #endregion

        // HOTKEYS
        #region HOTKEYS
        private void OnCancelPressed()
        {
            if (_containerUIModel.IsContainerUIOpen.Value)
                _containerUIModel.SetContainerOpenState(false, null);
        }
        #endregion

        // ITEM INTERACTIONS RELATED
        #region
        private void OnItemInteracted(string itemID)
        {
            if (itemID == null)
                return;

            if (_containersModel.ContainersRepository.TryGetContainerByID(_containerUIModel.ContainerID, out ContainerData containerData))
            {
                if (TryGetItemData(containerData, itemID, out ItemData itemData))
                {
                    if (itemData.ItemAmount < 6)
                    {
                        TakeItems(_containerUIModel.ContainerID, itemID, itemData.ItemConfigKey, 1);
                    }
                }
                else
                {
                    ShowAmountSelectionUI(_containerUIModel.ContainerID, itemID, itemData.ItemAmount);
                }
            }

            _containerUIModel.InteractedItemID.Value = null;
        }

        private void ShowAmountSelectionUI(string containerID, string itemID, int itemAmount)
        {
            throw new NotImplementedException();
        }

        private void TakeItems(string containerID, string itemID, string itemConfigKey, int amountToTake)
        {
            if (_containersModel.ItemDatabase.TryGetConfig(itemConfigKey, out ItemConfig itemConfig))
            {
                _containersModel.ContainersRepository.RemoveItem(containerID, itemID, amountToTake);
                AddItemData addItemData = new(itemConfig.ItemConfigKey, amountToTake);
                _inventoryModel.AddItem.OnNext(addItemData);

                OnItemRemoved(itemID);
            }
        }

        private void OnItemRemoved(string itemID)
        {
            if (_containersModel.ContainersRepository.TryGetContainerByID(_containerUIModel.ContainerID, out ContainerData containerData))
            {
                if (TryGetItemData(containerData, itemID, out ItemData itemData))
                {
                    if (TryGetItemUIModel(itemID, out ItemUIModel itemToUpdateAmount))
                        itemToUpdateAmount.ItemAmount.Value = itemData.ItemAmount;
                }
                else
                {
                    if (TryGetItemUIModel(itemID, out ItemUIModel itemToRemove))
                        _containerUIModel.Items.Remove(itemToRemove);
                }
            }
        }

        #endregion

        private bool TryGetItemData(ContainerData containerData, string itemID, out ItemData itemData)
        {
            foreach (var item in containerData.Items)
            {
                if (item.ItemID == itemID)
                {
                    itemData = item;
                    return true;
                }
            }

            itemData = null;
            return false;
        }

        private bool TryGetItemUIModel(string itemID, out ItemUIModel itemToRemove)
        {
            foreach (ItemUIModel item in _containerUIModel.Items)
            {
                if (item.UniqueID == itemID)
                {
                    itemToRemove = item;
                    return true;
                }
            }
            itemToRemove = null;
            return false;
        }
    }
}
