using DataSystem;
using System;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace InventorySystem
{
    public class InventoryPresenter : IStartable, IDisposable
    {
        [Inject] private readonly InventoryModel _model;

        private CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public void Start()
        {
            _model.InventoryRepository.LoadData();

            AddItem("Coins", 20); // temp debug
        }

        public void AddItem(string configKey, int quantity)
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
                ItemData itemData = new ItemData(uniqueID, configKey, quantity);
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