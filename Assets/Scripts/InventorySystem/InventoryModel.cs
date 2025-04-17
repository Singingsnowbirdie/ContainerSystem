using DataSystem;
using UniRx;

namespace InventorySystem
{
    public class InventoryModel
    {
        public ISubject<AddItemData> AddItem { get; } = new Subject<AddItemData>();

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

    public readonly struct AddItemData
    {
        public AddItemData(string itemConfigKey, int amountToAdd) : this()
        {
            ItemConfigKey = itemConfigKey;
            AmountToAdd = amountToAdd;
        }

        public int AmountToAdd { get; }
        public string ItemConfigKey { get; }
    }
}