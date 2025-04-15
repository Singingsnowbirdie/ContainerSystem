using DataSystem;
using Player;
using System.Collections.Generic;
using UI;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ContainerSystem
{
    public class ContainersPresenter : IStartable
    {
        [Inject] private readonly ContainersModel _model;
        [Inject] private readonly ContainersView _view;
        [Inject] private readonly ContainerUIModel _containerUIModel;

        [Inject] private readonly PlayerStatsModel _playerStatsModel;
        private ContainerFactory _containerFactory;

        public void Start()
        {
            _containerFactory = new ContainerFactory(_model.ItemDatabase);

            ContainerView[] containerViews = _view.GetComponentsInChildren<ContainerView>();
            HashSet<string> uniqueIDs = new HashSet<string>();

            foreach (ContainerView containerView in containerViews)
            {
                if (containerView.TryGetUniqueID(out string uniqueID))
                {
                    uniqueIDs.Add(uniqueID);

                    RandomContentContainer containerModel = new RandomContentContainer(containerView.UniqueID);
                    containerView.SetContainerModel(containerModel);
                    _model.ContainerModels[containerView.UniqueID] = containerModel;

                    containerModel.TryOpen
                        .Subscribe(OnTryOpen)
                        .AddTo(containerView);

                    _model.ContainerViews[containerView.UniqueID] = containerView;
                    _model.ContainersRepository.LoadData();
                }
            }
        }

        private void OnTryOpen(ContainerOpenData data)
        {
            if (_model.ContainersRepository.TryGetContainerByID(data.UniqueID, out ContainerData containerData))
            {
                Debug.Log($"There is already a container with ID {data.UniqueID} in the repository");
                _containerUIModel.SetContainerOpenState(true, containerData);
            }
            else
            {
                Debug.Log($"Container with ID {data.UniqueID} was not found in the repository and will be created.");
                ContainerData newContainer = _containerFactory.CreateNewContainer(data.UniqueID, data.ContainerType, _playerStatsModel.CurrentPlayerLevel.Value);
                _model.ContainersRepository.AddContainer(newContainer);
                _containerUIModel.SetContainerOpenState(true, newContainer);
            }
        }
    }
}