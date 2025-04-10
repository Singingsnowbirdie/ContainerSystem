using System.Collections.Generic;

namespace ItemSystem
{
    public class ShieldsFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddShields();
        }

        private void AddShields()
        {
            const EItemType HeavyShieldType = EItemType.HeavyShield;
            const EItemType LightShieldType = EItemType.LightShield;
            const float HeavyShieldWeight = 4.0f;
            const float LightShieldWeight = 2.0f;

            void AddHeavyShield(string id, string name, int tier)
            {
                AddConfig(new ShieldConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = HeavyShieldWeight - (tier * 0.2f), // Reduce weight with increasing tier
                    BasicCost = 50 * tier,
                    ItemType = HeavyShieldType,
                    Defense = 10 + (tier * 5), // Defense grows with tier
                    Tier = tier
                });
            }

            void AddLightShield(string id, string name, int tier)
            {
                AddConfig(new ShieldConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = LightShieldWeight - (tier * 0.1f), // Less weight loss
                    BasicCost = 30 * tier,
                    ItemType = LightShieldType,
                    Defense = 5 + (tier * 3), // Less protection than heavy ones
                    Tier = tier
                });
            }

            // Heavy Shields (5 Tiers)
            AddHeavyShield("shield_heavy_1", "Iron Kite Shield", 1);
            AddHeavyShield("shield_heavy_2", "Steel Tower Shield", 2);
            AddHeavyShield("shield_heavy_3", "Reinforced Battle Shield", 3);
            AddHeavyShield("shield_heavy_4", "Obsidian Aegis", 4);
            AddHeavyShield("shield_heavy_5", "Dragonbone Bulwark", 5);

            // Light Shields (5 Tiers)
            AddLightShield("shield_light_1", "Wooden Buckler", 1);
            AddLightShield("shield_light_2", "Bronze Round Shield", 2);
            AddLightShield("shield_light_3", "Silver Parrying Shield", 3);
            AddLightShield("shield_light_4", "Mithril Ward", 4);
            AddLightShield("shield_light_5", "Phoenix Wing Shield", 5);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

