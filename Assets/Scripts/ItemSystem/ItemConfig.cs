using Localization;

namespace ItemSystem
{
    public abstract class ItemConfig
    {
        public ItemConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemTypeIcon itemTypeIcon)
        {
            ItemConfigKey = itemConfigKey;
            ItemDefaultName = itemName;
            Weight = weight;
            BasicСost = basicСost;
            ItemTypeIcon = itemTypeIcon;
        }

        public string ItemConfigKey { get; }
        public string ItemDefaultName { get; }
        public float Weight { get; }
        public int BasicСost { get; }
        public EItemTypeIcon ItemTypeIcon { get; }
        public abstract bool CanBeEquipped { get; }
        public abstract ELocalizationRegion LocalizationRegion { get; }
    }

    public class FoodConfig : ItemConfig
    {
        public FoodConfig(string itemConfigKey, string itemName, float weight,
            int basicСost, EItemTypeIcon itemTypeIcon, EFoodType foodType, bool isIngredient
            ) :
            base(itemConfigKey, itemName, weight, basicСost, itemTypeIcon)
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
        public AlchemyIngredientConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemTypeIcon itemTypeIcon) :
            base(itemConfigKey, itemName, weight, basicСost, itemTypeIcon)
        {
        }
        public override bool CanBeEquipped => false;

        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.AlchemyName;
    }

    public class PotionConfig : ItemConfig
    {
        public PotionConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemTypeIcon itemTypeIcon) :
            base(itemConfigKey, itemName, weight, basicСost, itemTypeIcon)
        {
        }

        public override bool CanBeEquipped => false;

        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.PotionName;
    }

    public abstract class EquipmentConfig : ItemConfig
    {
        public EquipmentConfig(string itemConfigKey, string itemName, float weight, int basicСost, EItemTypeIcon itemTypeIcon) :
            base(itemConfigKey, itemName, weight, basicСost, itemTypeIcon)
        {
        }
        public override bool CanBeEquipped => true;
        public override ELocalizationRegion LocalizationRegion => throw new System.NotImplementedException();
    }
}

