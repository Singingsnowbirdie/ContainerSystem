namespace ItemSystem
{
    public class ItemConfig
    {
        public ItemConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemIconType itemIconType)
        {
            ItemConfigKey = itemConfigKey;
            ItemName = itemName;
            Weight = weight;
            BasicСost = basicСost;
            ItemIconType = itemIconType;
        }

        public string ItemConfigKey { get; }
        public string ItemName { get; }
        public float Weight { get; }
        public int BasicСost { get; }
        public EItemIconType ItemIconType { get; }
        public bool CanBeEquipped { get; protected set; }
    }

    public class FoodConfig : ItemConfig
    {
        public FoodConfig(string itemConfigKey, string itemName, float weight,
            int basicСost, EItemIconType itemIconType, EFoodType foodType, bool isIngredient
            ) :
            base(itemConfigKey, itemName, weight, basicСost, itemIconType)
        {
            FoodType = foodType;
            IsIngredient = isIngredient;
            CanBeEquipped = false;
        }

        public EFoodType FoodType { get; }
        public bool IsIngredient { get; }
    }

    public class EquipmentConfig : ItemConfig
    {
        public EquipmentConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemIconType itemIconType) :
            base(itemConfigKey, itemName, weight, basicСost, itemIconType)
        {
            CanBeEquipped = true;
        }
    }
}

