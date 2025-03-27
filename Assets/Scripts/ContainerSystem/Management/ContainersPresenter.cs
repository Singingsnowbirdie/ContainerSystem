using DataSystem;
using ItemSystem;
using System.Collections.Generic;
using UniRx;
using Utilities;
using VContainer;
using VContainer.Unity;

namespace ContainerSystem
{
    public class ContainersPresenter : IStartable
    {
        [Inject] private readonly ContainersModel _model;
        [Inject] private readonly ContainersView _view;
        [Inject] private readonly ContainerUIModel _containerUIModel;
        [Inject] private readonly ItemDatabase _itemDatabase;

        private ContainerFactory _containerFactory;

        public void Start()
        {
            _containerFactory = new ContainerFactory(_itemDatabase);

            ContainerView[] containerViews = _view.GetComponentsInChildren<ContainerView>();
            HashSet<string> uniqueIDs = new HashSet<string>();

            foreach (ContainerView containerView in containerViews)
            {
                if (containerView.TryGetUniqueID(out string uniqueID))
                {
                    uniqueIDs.Add(uniqueID);
                }
                else
                {
                    uniqueID = IDGenerator.GenerateUniqueID(uniqueIDs);
                    containerView.SetUniqueID(uniqueID);
                    uniqueIDs.Add(uniqueID);
                }

                if (containerView.ContainerType == EContainerType.Barrel)
                {
                    SupplyContainerModel containerModel = new SupplyContainerModel(containerView.UniqueID);
                    _model.ContainerModels[containerView.UniqueID] = containerModel;

                    containerModel.TryOpen
                        .Subscribe(OnTryOpen)
                        .AddTo(containerView);
                }

                _model.ContainerViews[containerView.UniqueID] = containerView;
                _model.ContainersRepository.LoadData();
            }
        }

        private void OnTryOpen(ContainerOpenData data)
        {
            if (_model.ContainersRepository.TryGetContainerByID(data.UniqueID, out ContainerData containerData))
            {
                _containerUIModel.OpenContainerUI.OnNext(containerData);
            }
            else
            {
                ContainerData newContainer = _containerFactory.CreateNewContainer(data.UniqueID, data.ContainerType);
                _model.ContainersRepository.AddContainer(newContainer);
                _containerUIModel.OpenContainerUI.OnNext(newContainer);
            }
        }
    }
}