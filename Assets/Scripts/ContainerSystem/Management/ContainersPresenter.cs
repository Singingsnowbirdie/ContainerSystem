using DataSystem;
using ItemSystem;
using Player;
using System;
using System.Collections.Generic;
using UI;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ContainerSystem
{
    public class ContainersPresenter : IStartable, IDisposable
    {
        [Inject] private readonly ContainersModel _model;
        [Inject] private readonly ContainersView _view;
        [Inject] private readonly ContainerUIModel _containerUIModel;

        [Inject] private readonly PlayerStatsModel _playerStatsModel;
        private ContainerFactory _containerFactory;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

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

                    ContainerModel containerModel = new ContainerModel(containerView.UniqueID);
                    containerView.SetContainerModel(containerModel);
                    _model.ContainerModels[containerView.UniqueID] = containerModel;

                    containerModel.TryOpen
                        .Subscribe(OnTryOpen)
                        .AddTo(containerView);

                    if (containerView is BookshelfView)
                    {
                        containerModel.InteractionCompleted
                            .Subscribe(OnInteractionCompleted)
                            .AddTo(containerView);
                    }

                    _model.ContainerViews[containerView.UniqueID] = containerView;
                    _model.ContainersRepository.LoadData();
                }
            }

            _model.AddItem
                .Subscribe(x => AddItem(x.ContainerID, x.ItemConfigKey, x.AmountToAdd))
                .AddTo(_compositeDisposable);
        }

        private void OnInteractionCompleted(ContainerInteractionCompletedData data)
        {
            if (_model.ContainersRepository.TryGetContainerByID(data.UniqueID, out ContainerData containerData))
            {
                data.ShelfView.UpdateShelfItems(containerData);
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

        internal void AddItem(string containerID, string itemConfigKey, int amount)
        {
            if (!_model.ContainersRepository.TryGetContainerByID(containerID, out ContainerData containerData))
            {
                Debug.LogError($"Container with ID '{containerID}' not found");
                return;
            }

            if (_model.ContainersRepository.TryGetItemDataByConfigKey(containerData, itemConfigKey, out ItemData existingItem))
            {
                existingItem.ItemAmount += amount;
            }
            else
            {
                if (_model.ItemDatabase.TryGetConfig(itemConfigKey, out ItemConfig itemConfig))
                {
                    string uniqueID = GenerateUniqueID(containerID);
                    ItemData itemData = new(uniqueID, itemConfig.ItemType, itemConfigKey, amount);
                    _model.ContainersRepository.AddItem(containerID, itemData);
                }
            }
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        private string GenerateUniqueID(string containerID)
        {
            const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new System.Random();
            string newId;

            do
            {
                var stringChars = new char[8];
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = CHARS[random.Next(CHARS.Length)];
                }
                newId = new string(stringChars);
            }
            while (_model.ContainersRepository.ItemExists(containerID, newId));

            return newId;
        }

    }
}