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
        }

        private string GetLocalizedName(string key)
        {
            if (_localizationModel.TryGetTranslation(ELocalizationRegion.ContainerUI, key, out string translation))
                return translation;

            return _localizationMissed;
        }
    }
}
