﻿using Localization;
using System;

namespace ItemSystem
{
    public abstract class ItemConfig
    {
        // Init
        public string ItemConfigKey { get; init; }
        public string ItemDefaultName { get; init; }
        public float Weight { get; init; }
        public int BasicCost { get; init; }
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

    public class IngredientConfig : ItemConfig
    {
        // Ingredient properties
        public int IngredientLevel { get; internal set; }

        // Implementation of abstract properties
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.AlchemyName;

    }

    public class PotionConfig : ItemConfig
    {
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.PotionName;
        public int PotionLevel { get; init; }
        public EPlayerStat AffectedStat { get; init; }
        public int StatIncrease { get; init; }
        public bool IsInstantEffect { get; init; }
        public float BoostMultiplier { get; init; }
        public float EffectDuration { get; init; }
        public bool HasHarmfulEffect { get; init; }
        public float TickInterval { get; init; }

        public EPotionType PotionType => DeterminePotionType();

        private EPotionType DeterminePotionType()
        {
            if (HasHarmfulEffect)
                return EPotionType.Poison;

            return AffectedStat switch
            {
                EPlayerStat.Health => EPotionType.HealthPotion,
                EPlayerStat.Mana => EPotionType.ManaPotion,
                EPlayerStat.Stamina => EPotionType.StaminaPotion,
                _ => throw new InvalidOperationException($"Unknown potion type for stat {AffectedStat}")
            };
        }
    }

    public abstract class EquipmentConfig : ItemConfig
    {
        public override bool CanBeEquipped => true;
        public abstract override ELocalizationRegion LocalizationRegion { get; }
        public EEquipmentClass EquipmentClass { get; init; }
        public int Tier { get; internal set; }
    }

    public class WeaponConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.WeaponName;

        // Additional properties of weapons
        public int Damage { get; init; }
        public EWeaponClass WeaponClass { get; internal set; }
    }

    public class ArmorConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.ArmorName;

        // Specific properties 
        public EArmorType ArmorType { get; init; }
        public EArmorClass ArmorClass { get; internal set; }
        public int Defense { get; init; }
    }

    public class AccessoryConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.AccessoryName;

        // Specific properties 
    }

    public class ShieldConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.ShieldName;

        // Specific properties 
        public int Defense { get; init; }
    }

    public class AmmoConfig : EquipmentConfig
    {
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.AmmunitionName;

        // Specific properties 
        public int Damage { get; internal set; }
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

    public abstract class MiscellaneousConfig : ItemConfig
    {
        public override bool CanBeEquipped => false;
        public abstract override ELocalizationRegion LocalizationRegion { get; }
    }

    public class JunkConfig : MiscellaneousConfig
    {
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.JunkName;
    }

    public class ValuableConfig : MiscellaneousConfig
    {
        public override bool CanBeEquipped => false;
        public override ELocalizationRegion LocalizationRegion => ELocalizationRegion.ValuableName;
    }
}