namespace ItemSystem
{
    public class ItemConfig
    {
        public ItemConfig(string itemID, string itemName, float weight, int basicСost, bool isCulinary, bool isAlchemy)
        {
            ItemID = itemID;
            ItemName = itemName;
            Weight = weight;
            BasicСost = basicСost;
            IsCulinary = isCulinary;
            IsAlchemy = isAlchemy;
        }

        public string ItemID { get; }
        public string ItemName { get; }
        public float Weight { get; }
        public int BasicСost { get; }
        public bool IsFood { get; protected set; }
        public bool IsCulinary { get; }
        public bool IsAlchemy { get; }
    }

    public class FoodConfig : ItemConfig
    {
        public EFoodType FoodType { get; }

        public FoodConfig(string itemID, string itemName, float weight,
            int basicCost, bool isCulinary, bool isAlchemy,
            EFoodType foodType)
            : base(itemID, itemName, weight, basicCost, isCulinary, isAlchemy)
        {
            IsFood = true;
            FoodType = foodType;
        }
    }

    public class EquipmentConfig : ItemConfig
    {
        public EquipmentConfig(string itemID, string itemName, float weight,
            int basicСost, bool isCulinary, bool isAlchemy) :
            base(itemID, itemName, weight, basicСost, isCulinary, isAlchemy)
        {
        }
    }
}

