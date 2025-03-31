using ContainerSystem;
using DataSystem;
using ItemSystem;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using static UnityEditor.Progress;

namespace UI
{
    public class ContainerUIPresenter : IStartable
    {
        // This UI
        [Inject] private readonly ContainerUIModel _containerUIModel;
        [Inject] private readonly ContainerUIView _containerUIView;

        // Other
        [Inject] private readonly ContainersModel _containersModel;

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
                if (_containersModel.ItemDatabase.TryGetConfig(itemData.ItemID, out ItemConfig itemConfig))
                {
                    ItemUIModel uiModel = new(itemData, itemConfig);
                    _containerUIModel.Items.Add(uiModel);
                }
            }

            _containerUIView.ShowContainerUI(true);
        }
    }
}
