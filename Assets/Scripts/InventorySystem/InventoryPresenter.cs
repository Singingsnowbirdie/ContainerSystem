using ContainerSystem;
using DataSystem;
using ItemSystem;
using System;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InventorySystem
{
    public class InventoryPresenter : IStartable, IDisposable
    {
        [Inject] private readonly InventoryModel _model;
        [Inject] private readonly ContainersModel _containersModel;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public void Start()
        {
            _model.InventoryRepository.LoadData();

            AddItem("Coin", 20); // temp debug

            _model.AddItem
                .Subscribe(x => AddItem(x.ItemConfigKey, x.AmountToAdd))
                .AddTo(_compositeDisposable);
        }

        public void AddItem(string itemConfigKey, int quantity)
        {
            if (quantity < 1)
                return;

            if (_model.InventoryRepository.TryGetItemByConfigKey(itemConfigKey, out ItemData existingItem))
            {
                existingItem.ItemAmount += quantity;
            }
            else
            {
                if (_containersModel.ItemDatabase.TryGetConfig(itemConfigKey, out ItemConfig itemConfig))
                {
                    string uniqueID = GenerateUniqueID();
                    ItemData itemData = new(uniqueID, itemConfig.ItemType, itemConfigKey, quantity);
                    _model.InventoryRepository.AddItem(itemData);
                }
            }

            Debug.Log($"Item {itemConfigKey} added to inventory");
        }

        public void RemoveItem(string itemId, int quantity)
        {
            if (quantity < 1)
                return;

            if (_model.InventoryRepository.TryGetItemByID(itemId, out ItemData existingItem))
            {
                existingItem.ItemAmount -= quantity;

                if (existingItem.ItemAmount <= 0)
                    _model.InventoryRepository.RemoveItemById(itemId);
            }
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        // PRIVATE METODS
        private string GenerateUniqueID()
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
            while (_model.InventoryRepository.ItemExists(newId));

            return newId;
        }



    }
}