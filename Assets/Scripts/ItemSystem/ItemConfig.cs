using Localization;

namespace ItemSystem
{
    public abstract class ItemConfig
    {
        // Init
        public string ItemConfigKey { get; init; }
        public string ItemDefaultName { get; init; }
        public float Weight { get; init; }
        public int BasicСost { get; init; }
        public EItemType ItemType { get; init; }

        // Abstract
        public abstract bool CanBeEquipped { get; }
        public abstract ELocalizationRegion LocalizationRegion { get; }
    }

    public class FoodConfig : ItemConfig
    {
        // Food properties
        public EFoodType FoodType { get; init; }
        public bool IsIngredient { get; init; }

        // Implementation of abstract properties
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.FoodName;
    }

    public class AlchemyIngredientConfig : ItemConfig
    {
        // Implementation of abstract properties
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.AlchemyName;
    }

    public class PotionConfig : ItemConfig
    {
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.PotionName;
    }

    public abstract class EquipmentConfig : ItemConfig
    {
        public override bool CanBeEquipped => true;
        public abstract override ELocalizationRegion LocalizationRegion { get; }
        public EEquipmentClass EquipmentClass { get; init; }
    }

    public class WeaponConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.WeaponName;

        // Additional properties of weapons
        public EWeaponType WeaponType { get; init; }
        public int Damage { get; init; }
        public float AttackSpeed { get; init; }
    }

    public class ArmorConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.ArmorName;

        // Specific properties of armor
        public EArmorType ArmorType { get; init; }
        public int Defense { get; init; }
        public float MobilityModifier { get; init; } = 1.0f;
    }

    public class BookConfig : ItemConfig
    {
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.BookName;

        // Additional properties of books
        public EBookType BookType { get; init; }
    }

    public class KeyConfig : ItemConfig
    {
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.KeyName;

        // Key specific properties
        public string TargetLockId { get; init; }
 
    }
}