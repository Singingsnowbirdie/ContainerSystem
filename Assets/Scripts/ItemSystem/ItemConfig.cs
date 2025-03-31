namespace ItemSystem
{
    public class ItemConfig
    {
        public ItemConfig(string itemID, string itemName, float weight, int basicСost, EItemIconType itemIconType)
        {
            ItemID = itemID;
            ItemName = itemName;
            Weight = weight;
            BasicСost = basicСost;
            ItemIconType = itemIconType;
        }

        public string ItemID { get; }
        public string ItemName { get; }
        public float Weight { get; }
        public int BasicСost { get; }
        public EItemIconType ItemIconType { get; }
    }

    public class FoodConfig : ItemConfig
    {
        public FoodConfig(string itemID, string itemName, float weight, 
            int basicСost, EItemIconType itemIconType, EFoodType foodType, bool isIngredient
            ) : 
            base(itemID, itemName, weight, basicСost, itemIconType)
        {
            FoodType = foodType;
            IsIngredient = isIngredient;
        }

        public EFoodType FoodType { get; }
        public bool IsIngredient { get; }
    }

    public class EquipmentConfig : ItemConfig
    {
        public EquipmentConfig(string itemID, string itemName, float weight, int basicСost, EItemIconType itemIconType) : 
            base(itemID, itemName, weight, basicСost, itemIconType)
        {
        }
    }
}

