using ContainerSystem;
using DataSystem;
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

            _menuInputHandler.OnCancelPressed
                .Subscribe(_ => OnCancelPressed())
                .AddTo(_containerUIView);

            _localizationHandler.Localize(_localizationModel, _containerUIModel, _containerUIView);
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
            // Items
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
                        ItemTypeIcon = new ReactiveProperty<EItemType>(itemConfig.ItemType),
                        ItemCost = new ReactiveProperty<int>(itemConfig.BasicСost),
                    };

                    uiModel.ItemType.Value = _localizationHandler.GetItemTypeTranslation(itemConfig);
                    uiModel.ItemName.Value = _localizationHandler.GetItemNameTranslation(itemConfig);
                    uiModel.EquipmentClass.Value = _localizationHandler.GetEquipmentClassTranslation(itemConfig);

                    _containerUIModel.Items.Add(uiModel);
                }
            }

            _containerUIModel.SortingButtonsAreaModel.SortingType.Value = ESortingType.NameUp;

            if (_containerUIModel.Items.Count > 0)
                _containerUIModel.Items[0].IsSelected.Value = true;

            // Filters
            _containerUIModel.ItemFilters.Clear();
            _containerUIModel.ItemFilters.AddRange(CreateContainerFilters());
        }

        // SORTING
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

        // FILTERS
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

                filterModel.SelectFilter
                    .Subscribe(val => OnFilterSelected(val))
                .AddTo(_containerUIView);

                filterModel.FilteredItems.AddRange(GetFilteredItems(filterType));

                filtersList.Add(filterModel);
            }

            return filtersList;
        }

        private void OnFilterSelected(SelectFilterData val)
        {
            _containerUIModel.SelectedFilter.Value = val.FilterType;
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
    }
}
