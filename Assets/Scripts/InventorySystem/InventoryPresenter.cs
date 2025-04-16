using DataSystem;
using ItemSystem;
using System;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace InventorySystem
{
    public class InventoryPresenter : IStartable, IDisposable
    {
        [Inject] private readonly InventoryModel _model;

        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public void Start()
        {
            _model.InventoryRepository.LoadData();

            AddItem(EItemType.Coin, "Coins", 20); // temp debug
        }

        public void AddItem(EItemType itemType, string configKey, int quantity)
        {
            if (quantity < 1)
                return;

            if (_model.InventoryRepository.TryGetItemByConfigKey(configKey, out ItemData existingItem))
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                string uniqueID = GenerateUniqueID();
                ItemData itemData = new(uniqueID, itemType, configKey, quantity);
                _model.InventoryRepository.AddItem(itemData);
                _model.InventoryRepository.SaveData();
            }
        }

        public void RemoveItem(string itemId, int quantity)
        {
            if (quantity < 1)
                return;

            if (_model.InventoryRepository.TryGetItemByID(itemId, out ItemData existingItem))
            {
                existingItem.Quantity -= quantity;

                if (existingItem.Quantity <= 0)
                    _model.InventoryRepository.RemoveItemById(itemId);
            }

            _model.InventoryRepository.SaveData();
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }

        // PRIVATE METODS
        private string GenerateUniqueID()
        {
            const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
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