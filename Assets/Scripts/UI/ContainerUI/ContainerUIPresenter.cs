using ContainerSystem;
using DataSystem;
using ItemSystem;
using Localization;
using UniRx;
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

        public void Start()
        {
            _containerUIView.OnSetModel(_containerUIModel);

            _containerUIModel.OpenContainerUI
                .Subscribe(OpenContainerUI)
                .AddTo(_containerUIView);
        }

        private void OpenContainerUI(ContainerData data)
        {
            _containerUIModel.Items.Clear();

            foreach (ItemData itemData in data.Items)
            {
                if (_containersModel.ItemDatabase.TryGetConfig(itemData.ItemConfigKey, out ItemConfig itemConfig))
                {
                    string itemName = GetItemName(itemConfig);

                    ItemUIModel uiModel = new(itemData, itemConfig, itemName);
                    _containerUIModel.Items.Add(uiModel);
                }
            }

            if (_containerUIModel.Items.Count > 0)
                _containerUIModel.Items[0].IsSelected.Value = true;

            _containerUIView.ShowContainerUI(true);
        }

        private string GetItemName(ItemConfig itemConfig)
        {
            if (_localizationModel.TryGetTranslation(itemConfig.LocalizationRegion,itemConfig.ItemConfigKey, out string translation))
            {
                return translation;
            }

            return itemConfig.ItemDefaultName;
        }
    }
}
