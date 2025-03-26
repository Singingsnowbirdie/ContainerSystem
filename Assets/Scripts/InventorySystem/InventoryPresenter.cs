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

        public void AddItem(string itemId, int quantity)
        {
            if (quantity < 1)
                return;

            if (_model.InventoryRepository.TryGetItemByID(itemId, out ItemData existingItem))
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _model.InventoryRepository.AddItem(itemId, quantity);
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
    }
}