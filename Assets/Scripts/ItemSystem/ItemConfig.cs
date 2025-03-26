namespace ItemSystem
{
    public class ItemConfig
    {
        public ItemConfig(string itemID, string itemName, float weight, float basicСost, bool isFood, bool isCulinary, bool isAlchemy)
        {
            ItemID = itemID;
            ItemName = itemName;
            Weight = weight;
            BasicСost = basicСost;
            IsFood = isFood;
            IsCulinary = isCulinary;
            IsAlchemy = isAlchemy;
        }

        public string ItemID { get; }
        public string ItemName { get; }
        public float Weight { get; }
        public float BasicСost { get; }
        public bool IsFood { get; }
        public bool IsCulinary { get; }
        public bool IsAlchemy { get; }
    }
}

