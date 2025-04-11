using System.Collections.Generic;

namespace ItemSystem
{
    public class AmmunitionFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddAmmunition();
        }

        private void AddAmmunition()
        {
            const EItemType IconType = EItemType.Arrow;

            void AddArrow(string id, string name, int tier)
            {
                AddConfig(new AmmoConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    ItemType = IconType,
                    Tier = tier,
                    BasicCost = 5 * tier, 
                    Damage = 2 + tier 
                });
            }

            AddArrow("arrow", "Flint Arrow", 1);
            AddArrow("arrow", "Bronze Arrow", 2);
            AddArrow("arrow", "Iron Arrow", 3);
            AddArrow("arrow", "Steel Arrow", 4);
            AddArrow("arrow", "Silver Arrow", 5);
            AddArrow("arrow", "Obsidian Arrow", 6);
            AddArrow("arrow", "Mithril Arrow", 7);
            AddArrow("arrow", "Dragonbone Arrow", 8);
            AddArrow("arrow", "Phoenix Feather Arrow", 9);
            AddArrow("arrow", "Celestial Arrow", 10);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

