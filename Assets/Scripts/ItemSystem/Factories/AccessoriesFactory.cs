using System.Collections.Generic;

namespace ItemSystem
{
    public class AccessoriesFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddAccessories();
        }

        private void AddAccessories()
        {
            const EItemType RingType = EItemType.Ring;
            const EItemType BeltType = EItemType.Belt;
            const EItemType TiaraType = EItemType.Tiara;
            const EItemType NecklaceType = EItemType.Necklace;

            void AddRing(string id, string name, int tier)
            {
                AddConfig(new AccessoryConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    ItemType = RingType,
                    Tier = tier,
                    BasicCost = 100 * tier
                });
            }

            void AddBelt(string id, string name, int tier)
            {
                AddConfig(new AccessoryConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    ItemType = BeltType,
                    Tier = tier,
                    BasicCost = 80 * tier
                });
            }

            void AddTiara(string id, string name, int tier)
            {
                AddConfig(new AccessoryConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    ItemType = TiaraType,
                    Tier = tier,
                    BasicCost = 150 * tier
                });
            }

            void AddNecklace(string id, string name, int tier)
            {
                AddConfig(new AccessoryConfig
                {
                    ItemConfigKey = $"{id}_{tier}",
                    ItemDefaultName = $"{name} (Tier {tier})",
                    ItemType = NecklaceType,
                    Tier = tier,
                    BasicCost = 120 * tier
                });
            }

            // Rings (5 tiers)
            AddRing("ring", "Copper Band", 1);
            AddRing("ring", "Silver Ring", 2);
            AddRing("ring", "Gold Signet", 3);
            AddRing("ring", "Platinum Circle", 4);
            AddRing("ring", "Dragonbone Hoop", 5);

            // Belts (5 tiers)
            AddBelt("belt", "Leather Strap", 1);
            AddBelt("belt", "Studded Girdle", 2);
            AddBelt("belt", "Silk Sash", 3);
            AddBelt("belt", "Mithril Chain", 4);
            AddBelt("belt", "Dragonhide Belt", 5);

            // Tiaras (5 tiers)
            AddTiara("tiara", "Bronze Circlet", 1);
            AddTiara("tiara", "Silver Diadem", 2);
            AddTiara("tiara", "Golden Crownlet", 3);
            AddTiara("tiara", "Crystal Coronet", 4);
            AddTiara("tiara", "Arcane Headdress", 5);

            // Necklaces (5 tiers)
            AddNecklace("necklace", "Beaded Strand", 1);
            AddNecklace("necklace", "Silver Pendant", 2);
            AddNecklace("necklace", "Gold Choker", 3);
            AddNecklace("necklace", "Platinum Torc", 4);
            AddNecklace("necklace", "Dragonfang Collar", 5);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

