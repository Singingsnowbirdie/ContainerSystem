using DataSystem;
using ItemSystem;

namespace UI
{
    public class ItemUIModel : UIModel
    {
        public ItemUIModel(ItemData itemData, ItemConfig itemConfig)
        {
            CanBeEquipped = itemConfig.CanBeEquipped;
            UniqueID = itemData.ItemID;
        }

        public bool CanBeEquipped { get; }
        public string UniqueID { get; }
    }
}