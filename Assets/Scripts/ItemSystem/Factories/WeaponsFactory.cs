using System;
using System.Collections.Generic;

namespace ItemSystem
{
    public class WeaponsFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddWeapons();
        }

        private void AddWeapons()
        {
            void AddOneHandedWeapon(string id, string name, EItemType itemType, int tier)
            {
                int baseCost = itemType == EItemType.Sword ? 100 : 80;
                int cost = baseCost * tier;

                // Weight decreases by 8% for each tier (but not less than 70% of the original)
                float weightReduction = 1.0f - (tier - 1) * 0.08f;
                weightReduction = Math.Max(weightReduction, 0.7f);
                float weight = 1.5f * weightReduction;

                AddConfig(new WeaponConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    WeaponClass = EWeaponClass.OneHandedWeapon,
                    ItemType = itemType,
                    Tier = tier,
                    BasicCost = cost,
                    Weight = weight 
                });
            }

            void AddTwoHandedWeapon(string id, string name, EItemType itemType, int tier)
            {
                int baseCost = itemType switch
                {
                    EItemType.Bow => 150,
                    EItemType.TwoHandedSword => 200,
                    EItemType.Staff => 180,
                    _ => 150
                };
                int cost = baseCost * tier;

                // Weight decreases by 6% for each tier (but not less than 75% of the original)
                float weightReduction = 1.0f - (tier - 1) * 0.06f;
                weightReduction = Math.Max(weightReduction, 0.75f);
                float weight = 3.0f * weightReduction;

                AddConfig(new WeaponConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    WeaponClass = EWeaponClass.TwoHandedWeapon,
                    ItemType = itemType,
                    Tier = tier,
                    BasicCost = cost,
                    Weight = weight 
                });
            }

            // One-handed weapons (5 tiers)
            // Swords
            AddOneHandedWeapon("sword", "Iron Shortsword", EItemType.Sword, 1);
            AddOneHandedWeapon("sword", "Steel Longsword", EItemType.Sword, 2);
            AddOneHandedWeapon("sword", "Silver Saber", EItemType.Sword, 3);
            AddOneHandedWeapon("sword", "Obsidian Blade", EItemType.Sword, 4);
            AddOneHandedWeapon("sword", "Dragonfang Sword", EItemType.Sword, 5);

            // Daggers
            AddOneHandedWeapon("dagger", "Bronze Dagger", EItemType.Dagger, 1);
            AddOneHandedWeapon("dagger", "Steel Dirk", EItemType.Dagger, 2);
            AddOneHandedWeapon("dagger", "Shadow Fang", EItemType.Dagger, 3);
            AddOneHandedWeapon("dagger", "Vorpal Blade", EItemType.Dagger, 4);
            AddOneHandedWeapon("dagger", "Assassin's Kris", EItemType.Dagger, 5);

            // Two-handed weapons (5 tiers)
            // Two-handed swords
            AddTwoHandedWeapon("greatsword", "Claymore", EItemType.TwoHandedSword, 1);
            AddTwoHandedWeapon("greatsword", "Zweihander", EItemType.TwoHandedSword, 2);
            AddTwoHandedWeapon("greatsword", "Flameberge", EItemType.TwoHandedSword, 3);
            AddTwoHandedWeapon("greatsword", "Blackblade", EItemType.TwoHandedSword, 4);
            AddTwoHandedWeapon("greatsword", "Titan's Cleaver", EItemType.TwoHandedSword, 5);

            // Bows
            AddTwoHandedWeapon("bow", "Shortbow", EItemType.Bow, 1);
            AddTwoHandedWeapon("bow", "Longbow", EItemType.Bow, 2);
            AddTwoHandedWeapon("bow", "Composite Bow", EItemType.Bow, 3);
            AddTwoHandedWeapon("bow", "Elven Bow", EItemType.Bow, 4);
            AddTwoHandedWeapon("bow", "Dragonbone Bow", EItemType.Bow, 5);

            // Staffs
            AddTwoHandedWeapon("staff", "Oak Staff", EItemType.Staff, 1);
            AddTwoHandedWeapon("staff", "Runed Staff", EItemType.Staff, 2);
            AddTwoHandedWeapon("staff", "Crystal Staff", EItemType.Staff, 3);
            AddTwoHandedWeapon("staff", "Archmage's Staff", EItemType.Staff, 4);
            AddTwoHandedWeapon("staff", "Elderwood Staff", EItemType.Staff, 5);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

