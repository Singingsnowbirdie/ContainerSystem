using DataSystem;
using ItemSystem;
using UniRx;

namespace UI
{
    public class ItemUIModel : UIModel
    {
        public ItemUIModel(ItemData itemData, ItemConfig itemConfig, string itemName)
        {
            CanBeEquipped = itemConfig.CanBeEquipped;
            UniqueID = itemData.ItemID;
            ItemTypeIcon.Value = itemConfig.ItemTypeIcon;
            ItemName.Value = itemName;
        }

        public bool CanBeEquipped { get; }
        public string UniqueID { get; }
        public ReactiveProperty<bool> IsSelected { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<EItemTypeIcon> ItemTypeIcon { get; } = new ReactiveProperty<EItemTypeIcon>();
        public ReactiveProperty<string> ItemName { get; } = new ReactiveProperty<string>();
    }
}