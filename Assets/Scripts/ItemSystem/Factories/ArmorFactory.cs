using System;
using System.Collections.Generic;

namespace ItemSystem
{
    public class ArmorFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddArmor();
        }

        private void AddArmor()
        {
            // Heavy Armor (5 Tiers)
            AddHeavyArmor("heavy", "Iron", 1, 50);
            AddHeavyArmor("heavy", "Steel", 2, 100);
            AddHeavyArmor("heavy", "Mithril", 3, 200);
            AddHeavyArmor("heavy", "Adamantine", 4, 400);
            AddHeavyArmor("heavy", "Dragonplate", 5, 800);

            // Light Armor (5 Tiers)
            AddLightArmor("light", "Leather", 1, 40);
            AddLightArmor("light", "Hardened Leather", 2, 80);
            AddLightArmor("light", "Chainmail", 3, 160);
            AddLightArmor("light", "Elven Steel", 4, 320);
            AddLightArmor("light", "Shadow Weave", 5, 640);

            // Clothes (5 tiers)
            AddClothArmor("cloth", "Linen", 1, 20);
            AddClothArmor("cloth", "Wool", 2, 40);
            AddClothArmor("cloth", "Silk", 3, 80);
            AddClothArmor("cloth", "Mageweave", 4, 160);
            AddClothArmor("cloth", "Arcane Cloth", 5, 320);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }

        // ARMOR ADDING METHODS
        #region ARMOR ADDING METHODS
        void AddHeavyArmor(string idPrefix, string material, int tier, int baseCost)
        {
            int cost = baseCost * tier;

            // Heavy Helmet
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_helm_{tier}",
                ItemDefaultName = $"{material} Helm",
                Weight = GetHeavyArmorWeight(EArmorType.Helmet, tier),
                BasicCost = cost,
                ItemType = EItemType.HeavyHelmet,
                ArmorType = EArmorType.Helmet,
                Tier = tier,
                Defense = GetHeavyArmorDefense(EArmorType.Helmet, tier)
            });

            // Heavy Chestplate
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_chest_{tier}",
                ItemDefaultName = $"{material} Chestplate",
                Weight = GetHeavyArmorWeight(EArmorType.Chest, tier),
                BasicCost = cost * 2, // Chest costs more
                ItemType = EItemType.HeavyChest,
                ArmorType = EArmorType.Chest,
                Tier = tier,
                Defense = GetHeavyArmorDefense(EArmorType.Chest, tier)
            });

            // Heavy Leggings
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_legs_{tier}",
                ItemDefaultName = $"{material} Leggings",
                Weight = GetHeavyArmorWeight(EArmorType.Legs, tier),
                BasicCost = (int)(cost * 1.5f), // Legs cost 1.5x base
                ItemType = EItemType.HeavyLegs,
                ArmorType = EArmorType.Legs,
                Tier = tier,
                Defense = GetHeavyArmorDefense(EArmorType.Legs, tier)
            });

            // Heavy Boots
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_boots_{tier}",
                ItemDefaultName = $"{material} Boots",
                Weight = GetHeavyArmorWeight(EArmorType.Boots, tier),
                BasicCost = cost,
                ItemType = EItemType.HeavyBoots,
                ArmorType = EArmorType.Boots,
                Tier = tier,
                Defense = GetHeavyArmorDefense(EArmorType.Boots, tier)
            });

            // Heavy Gauntlets
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_hands_{tier}",
                ItemDefaultName = $"{material} Gauntlets",
                Weight = GetHeavyArmorWeight(EArmorType.Gloves, tier),
                BasicCost = (int)(cost * 0.8f), // Gloves cost slightly less
                ItemType = EItemType.HeavyGloves,
                ArmorType = EArmorType.Gloves,
                Tier = tier,
                Defense = GetHeavyArmorDefense(EArmorType.Gloves, tier)
            });

        }

        void AddLightArmor(string idPrefix, string material, int tier, int baseCost)
        {
            int cost = baseCost * tier;

            // Light Helmet
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_helm_{tier}",
                ItemDefaultName = $"{material} Hood",
                Weight = GetLightArmorWeight(EArmorType.Helmet, tier),
                BasicCost = cost,
                ItemType = EItemType.LightHelmet,
                ArmorType = EArmorType.Helmet,
                Tier = tier,
                Defense = GetLightArmorDefense(EArmorType.Helmet, tier)
            });

            // Light Chest
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_chest_{tier}",
                ItemDefaultName = $"{material} Vest",
                Weight = GetLightArmorWeight(EArmorType.Chest, tier),
                BasicCost = (int)(cost * 1.8f), // Light chest costs less than heavy
                ItemType = EItemType.LightChest,
                ArmorType = EArmorType.Chest,
                Tier = tier,
                Defense = GetLightArmorDefense(EArmorType.Chest, tier)
            });

            // Light Leggings
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_legs_{tier}",
                ItemDefaultName = $"{material} Trousers",
                Weight = GetLightArmorWeight(EArmorType.Legs, tier),
                BasicCost = (int)(cost * 1.3f),
                ItemType = EItemType.LightLegs,
                ArmorType = EArmorType.Legs,
                Tier = tier,
                Defense = GetLightArmorDefense(EArmorType.Legs, tier)
            });

            // Light Boots
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_boots_{tier}",
                ItemDefaultName = $"{material} Boots",
                Weight = GetLightArmorWeight(EArmorType.Boots, tier),
                BasicCost = cost,
                ItemType = EItemType.LightBoots,
                ArmorType = EArmorType.Boots,
                Tier = tier,
                Defense = GetLightArmorDefense(EArmorType.Boots, tier)
            });

            // Light Gloves
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_hands_{tier}",
                ItemDefaultName = $"{material} Gloves",
                Weight = GetLightArmorWeight(EArmorType.Gloves, tier),
                BasicCost = (int)(cost * 0.7f),
                ItemType = EItemType.LightGloves,
                ArmorType = EArmorType.Gloves,
                Tier = tier,
                Defense = GetLightArmorDefense(EArmorType.Gloves, tier)
            });
        }

        void AddClothArmor(string idPrefix, string material, int tier, int baseCost)
        {
            int cost = baseCost * tier;

            // Cloth Headpiece
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_helm_{tier}",
                ItemDefaultName = $"{material} Hat",
                Weight = GetClothArmorWeight(EArmorType.Helmet, tier),
                BasicCost = cost,
                ItemType = EItemType.ClothHelmet,
                ArmorType = EArmorType.Helmet,
                Tier = tier,
                Defense = GetClothArmorDefense(EArmorType.Helmet, tier)
            });

            // Cloth Robe
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_chest_{tier}",
                ItemDefaultName = $"{material} Robe",
                Weight = GetClothArmorWeight(EArmorType.Chest, tier),
                BasicCost = (int)(cost * 1.5f),
                ItemType = EItemType.ClothChest,
                ArmorType = EArmorType.Chest,
                Tier = tier,
                Defense = GetClothArmorDefense(EArmorType.Chest, tier)
            });

            // Cloth Pants
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_legs_{tier}",
                ItemDefaultName = $"{material} Pants",
                Weight = GetClothArmorWeight(EArmorType.Legs, tier),
                BasicCost = (int)(cost * 1.1f),
                ItemType = EItemType.ClothLegs,
                ArmorType = EArmorType.Legs,
                Tier = tier,
                Defense = GetClothArmorDefense(EArmorType.Legs, tier)
            });

            // Cloth Shoes
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_boots_{tier}",
                ItemDefaultName = $"{material} Shoes",
                Weight = GetClothArmorWeight(EArmorType.Boots, tier),
                BasicCost = cost,
                ItemType = EItemType.ClothBoots,
                ArmorType = EArmorType.Boots,
                Tier = tier,
                Defense = GetClothArmorDefense(EArmorType.Boots, tier)
            });

            // Cloth Gloves
            AddConfig(new ArmorConfig
            {
                ItemConfigKey = $"{idPrefix}_hands_{tier}",
                ItemDefaultName = $"{material} Gloves",
                Weight = GetClothArmorWeight(EArmorType.Gloves, tier),
                BasicCost = (int)(cost * 0.6f),
                ItemType = EItemType.ClothGloves,
                ArmorType = EArmorType.Gloves,
                Tier = tier,
                Defense = GetClothArmorDefense(EArmorType.Gloves, tier)
            });
        }

        #endregion


        // COUNT DEFENCE
        #region COUNT DEFENCE
        private int GetHeavyArmorDefense(EArmorType armorType, int tier)
        {
            // Base Defense Values ​​for Heavy Armor by Type
            int baseDefense = armorType switch
            {
                EArmorType.Helmet => 8,
                EArmorType.Chest => 15,
                EArmorType.Legs => 12,
                EArmorType.Boots => 6,
                EArmorType.Gloves => 5,
                _ => 5
            };

            // Tier modifier (1-5)
            float tierMultiplier = 1 + (tier - 1) * 0.25f; // +25% for each tier

            return (int)(baseDefense * tierMultiplier);
        }

        private int GetLightArmorDefense(EArmorType armorType, int tier)
        {
            // Light armor provides approximately 60% of the protection of heavy armor.
            int baseDefense = armorType switch
            {
                EArmorType.Helmet => 5,
                EArmorType.Chest => 9,
                EArmorType.Legs => 7,
                EArmorType.Boots => 4,
                EArmorType.Gloves => 3,
                _ => 3
            };

            float tierMultiplier = 1 + (tier - 1) * 0.2f; // +20% for each tier

            return (int)(baseDefense * tierMultiplier);
        }

        private int GetClothArmorDefense(EArmorType armorType, int tier)
        {
            // Clothing provides approximately 40% of the protection of heavy armor.
            int baseDefense = armorType switch
            {
                EArmorType.Helmet => 2,
                EArmorType.Chest => 4,
                EArmorType.Legs => 3,
                EArmorType.Boots => 2,
                EArmorType.Gloves => 1,
                _ => 1
            };

            float tierMultiplier = 1 + (tier - 1) * 0.15f; // +15% for each tier

            return (int)(baseDefense * tierMultiplier);
        }
        #endregion


        // COUNT WEIGHT
        #region COUNT WEIGHT
        private float GetHeavyArmorWeight(EArmorType type, int tier)
        {
            // Base weight for each armor type (tier 1)
            float baseWeight = type switch
            {
                EArmorType.Helmet => 2.5f,
                EArmorType.Chest => 8.0f,
                EArmorType.Legs => 5.0f,
                EArmorType.Boots => 3.0f,
                EArmorType.Gloves => 1.5f,
                _ => 1.0f
            };

            // Weight modifier depending on tier (the higher the tier, the lighter)
            // Each subsequent tier reduces weight by 8% (maximum reduction to tier 5 ~28%)
            float weightReduction = 1.0f - (tier - 1) * 0.08f;

            // We provide a minimum weight (not less than 70% of the original)
            weightReduction = Math.Max(weightReduction, 0.7f);

            return baseWeight * weightReduction;
        }

        private float GetLightArmorWeight(EArmorType type, int tier)
        {
            // Base weight for each armor type (tier 1)
            float baseWeight = type switch
            {
                EArmorType.Helmet => 1.0f,
                EArmorType.Chest => 4.0f,
                EArmorType.Legs => 2.5f,
                EArmorType.Boots => 1.5f,
                EArmorType.Gloves => 0.8f,
                _ => 1.0f
            };

            // Weight modifier - lighter armor gets smaller reduction (5% per tier)
            float weightReduction = 1.0f - (tier - 1) * 0.05f;

            // Minimum weight (not less than 80% of original)
            weightReduction = Math.Max(weightReduction, 0.8f);

            return baseWeight * weightReduction;
        }

        private float GetClothArmorWeight(EArmorType type, int tier)
        {
            // Base weight for each armor type (tier 1)
            float baseWeight = type switch
            {
                EArmorType.Helmet => 0.3f,
                EArmorType.Chest => 1.5f,
                EArmorType.Legs => 1.0f,
                EArmorType.Boots => 0.7f,
                EArmorType.Gloves => 0.3f,
                _ => 0.5f
            };

            // Weight modifier - cloth gets minimal reduction (3% per tier)
            float weightReduction = 1.0f - (tier - 1) * 0.03f;

            // Minimum weight (not less than 85% of original)
            weightReduction = Math.Max(weightReduction, 0.85f);

            return baseWeight * weightReduction;
        }
        #endregion
    }

}

