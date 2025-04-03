using Localization;

namespace ItemSystem
{
    public abstract class ItemConfig
    {
        public ItemConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemType itemType)
        {
            ItemConfigKey = itemConfigKey;
            ItemDefaultName = itemName;
            Weight = weight;
            BasicСost = basicСost;
            ItemType = itemType;
        }

        public string ItemConfigKey { get; }
        public string ItemDefaultName { get; }
        public float Weight { get; }
        public int BasicСost { get; }
        public EItemType ItemType { get; }
        public abstract bool CanBeEquipped { get; }
        public abstract ELocalizationRegion LocalizationRegion { get; }
    }

    public class FoodConfig : ItemConfig
    {
        public FoodConfig(string itemConfigKey, string itemName, float weight,
            int basicСost, EItemType itemType, EFoodType foodType, bool isIngredient
            ) :
            base(itemConfigKey, itemName, weight, basicСost, itemType)
        {
            FoodType = foodType;
            IsIngredient = isIngredient;
        }

        public EFoodType FoodType { get; }
        public bool IsIngredient { get; }

        public override bool CanBeEquipped => false;

        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.FoodName;
    }

    public class AlchemyIngredientConfig : ItemConfig
    {
        public AlchemyIngredientConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemType itemType) :
            base(itemConfigKey, itemName, weight, basicСost, itemType)
        {
        }
        public override bool CanBeEquipped => false;

        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.AlchemyName;
    }

    public class PotionConfig : ItemConfig
    {
        public PotionConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemType itemType) :
            base(itemConfigKey, itemName, weight, basicСost, itemType)
        {
        }

        public override bool CanBeEquipped => false;

        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.PotionName;
    }

    public abstract class EquipmentConfig : ItemConfig
    {
        public EquipmentConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemType itemType) :
            base(itemConfigKey, itemName, weight, basicСost, itemType)
        {
        }
        public override bool CanBeEquipped => true;
        public override ELocalizationRegion LocalizationRegion => throw new System.NotImplementedException();
        public EEquipmentClass EquipmentClass { get; protected set; }
    }

    public class WeaponConfig : EquipmentConfig
    {
        protected WeaponConfig(string itemConfigKey, string itemName, float weight, 
            int basicСost, EItemType itemType, EEquipmentClass equipmentClass) :
            base(itemConfigKey, itemName, weight, basicСost, itemType)
        {
            EquipmentClass = equipmentClass;
        }

    }

    public class ArmorConfig : EquipmentConfig
    {
        protected ArmorConfig(string itemConfigKey, string itemName, float weight, 
            int basicСost, EItemType itemType, EEquipmentClass equipmentClass) :
            base(itemConfigKey, itemName, weight, basicСost, itemType)
        {
            EquipmentClass = equipmentClass;
        }
    }
}