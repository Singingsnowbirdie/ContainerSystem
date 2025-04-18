using DataSystem;
using UniRx;

namespace InventorySystem
{
    public class InventoryModel
    {
        public ISubject<AddItemToInventoryData> AddItem { get; } = new Subject<AddItemToInventoryData>();

        private InventoryRepository _inventoryRepository;

        public InventoryRepository InventoryRepository
        {
            get
            {
                _inventoryRepository ??= new InventoryRepository();
                return _inventoryRepository;
            }
        }
    }

    public readonly struct AddItemToInventoryData
    {
        public AddItemToInventoryData(string itemConfigKey, int amountToAdd) : this()
        {
            ItemConfigKey = itemConfigKey;
            AmountToAdd = amountToAdd;
        }

        public int AmountToAdd { get; }
        public string ItemConfigKey { get; }
    }
}