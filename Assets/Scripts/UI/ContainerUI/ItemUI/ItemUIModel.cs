using DataSystem;
using ItemSystem;
using UniRx;

namespace UI
{
    public class ItemUIModel : UIModel
    {
        public ItemUIModel(ItemData itemData, ItemConfig itemConfig, string itemName, int itemCost, 
            string itemTypeStr, string equipmentClass, ContainerUIModel containerUIModel)
        {
            CanBeEquipped = itemConfig.CanBeEquipped;
            UniqueID = itemData.ItemID;
            ItemTypeIcon.Value = itemConfig.ItemType;
            ItemName.Value = itemName;
            ItemWeight.Value = itemConfig.Weight;
            ItemCost.Value = itemCost;
            EquipmentClass.Value = equipmentClass;
            ItemTypeStr.Value = itemTypeStr;
            ContainerUIModel = containerUIModel;
        }

        public bool CanBeEquipped { get; }
        public string UniqueID { get; }
        public ReactiveProperty<EItemType> ItemTypeIcon { get; } = new ReactiveProperty<EItemType>();
        public ReactiveProperty<string> ItemTypeStr { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> ItemName { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<float> ItemWeight { get; } = new ReactiveProperty<float>();
        public ReactiveProperty<int> ItemCost { get; } = new ReactiveProperty<int>();

        // EQUIPMENT ONLY
        public ReactiveProperty<string> EquipmentClass { get; } = new ReactiveProperty<string>();

        // CHANGEABLE
        public ReactiveProperty<bool> IsSelected { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<EContainerFilter> SelectedFilter { get; } = new ReactiveProperty<EContainerFilter>();

        // OTHER
        public ContainerUIModel ContainerUIModel { get; }
    }
}