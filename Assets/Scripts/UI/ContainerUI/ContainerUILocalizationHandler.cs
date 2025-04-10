using ItemSystem;
using Localization;
using UniRx;

namespace UI
{
    public class ContainerUILocalizationHandler
    {
        private string _localizationMissed = "!LocalizationMissed!";

        private LocalizationModel _localizationModel;
        private ContainerUIModel _containerUIModel;

        internal void Localize(LocalizationModel localizationModel, ContainerUIModel containerUIModel, ContainerUIView view)
        {
            _localizationModel = localizationModel;
            _containerUIModel = containerUIModel;

            localizationModel.CurrentLanguage
                .Subscribe(_ => OnCurrentLanguageUpdated())
                .AddTo(view);
        }

        private void OnCurrentLanguageUpdated()
        {
            _containerUIModel.HintText_Take.Value = GetLocalizedName("take");
            _containerUIModel.HintText_TakeAll.Value = GetLocalizedName("take_all");
            _containerUIModel.HintText_EquipMode.Value = GetLocalizedName("equipment_mode");

            _containerUIModel.ContainerSwitchAreaModel.InventoryName.Value = GetLocalizedName("inventory");
            _containerUIModel.ContainerSwitchAreaModel.ContainerName.Value = GetLocalizedName("container");

            _containerUIModel.SortingButtonsAreaModel.Sorting_Name.Value = GetLocalizedName("sorting_name");
            _containerUIModel.SortingButtonsAreaModel.Sorting_Type.Value = GetLocalizedName("sorting_type");
            _containerUIModel.SortingButtonsAreaModel.Sorting_Weight.Value = GetLocalizedName("sorting_weight");
            _containerUIModel.SortingButtonsAreaModel.Sorting_Cost.Value = GetLocalizedName("sorting_cost");
        }

        private string GetLocalizedName(string key)
        {
            if (_localizationModel.TryGetTranslation(ELocalizationRegion.ContainerUI, key, out string translation))
                return translation;

            return _localizationMissed;
        }

        public string GetItemTypeTranslation(ItemConfig itemConfig)
        {
            string localizationKey = itemConfig.ItemType.ToString();

            if (itemConfig.ItemType == EItemType.ManaPotion ||
                itemConfig.ItemType == EItemType.HealthPotion ||
                itemConfig.ItemType == EItemType.HealthPotion)
                localizationKey = "potion";

            if (_localizationModel.TryGetTranslation(ELocalizationRegion.ItemType, localizationKey, out string translation))
            {
                return translation;
            }
            return itemConfig.ItemType.ToString();
        }

        public string GetEquipmentClassTranslation(ItemConfig itemConfig)
        {
            if (itemConfig is EquipmentConfig equipmentConfig &&
                _localizationModel.TryGetTranslation(ELocalizationRegion.EquipmentClass, equipmentConfig.EquipmentClass.ToString(), out string translation))
            {
                return translation;
            }
            return null;
        }

        public string GetItemNameTranslation(ItemConfig itemConfig)
        {
            if (_localizationModel.TryGetTranslation(itemConfig.LocalizationRegion, itemConfig.ItemConfigKey, out string translation))
            {
                return translation;
            }

            return itemConfig.ItemDefaultName;
        }
    }
}
