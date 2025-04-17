using System.Collections.Generic;

namespace ItemSystem
{
    public class MiscellaneousFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddMiscellaneous();
        }

        private void AddMiscellaneous()
        {
            const EItemType JunkType = EItemType.Junk;
            const EItemType ValuableType = EItemType.Valuable;

            void AddJunk(string id, string name, int cost, float weight)
            {
                AddConfig(new JunkConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicCost = cost,
                    ItemType = JunkType
                });
            }

            void AddValuable(string id, string name, int cost, float weight)
            {
                AddConfig(new ValuableConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicCost = cost,
                    ItemType = ValuableType
                });
            }

            // Cheap junk (30 items, 1-25 coins) 
            AddJunk("junk_1", "Broken Dagger", 1, 0.8f);  // ~0.8 kg for a small dagger
            AddJunk("junk_2", "Torn Cloth", 1, 0.1f);     // Light fabric
            AddJunk("junk_3", "Rusty Nails", 2, 0.3f);    // Handful of nails
            AddJunk("junk_4", "Cracked Cup", 2, 0.4f);    // Ceramic cup
            AddJunk("junk_5", "Faded Painting", 3, 1.2f); // With frame
            AddJunk("junk_6", "Old Boot", 3, 0.7f);       // Single boot
            AddJunk("junk_7", "Empty Bottle", 1, 0.2f);   // Glass bottle
            AddJunk("junk_8", "Ruined Parchment", 2, 0.05f); // Very light
            AddJunk("junk_9", "Bent Coin", 1, 0.01f);     // Single coin
            AddJunk("junk_10", "Brick Fragment", 1, 0.5f); // Piece of brick
            AddJunk("junk_11", "Cracked Pot", 4, 1.5f);   // Cooking pot
            AddJunk("junk_12", "Worn Belt", 3, 0.3f);     // Leather belt
            AddJunk("junk_13", "Torn Net", 5, 1.0f);      // Fishing net
            AddJunk("junk_14", "Tarnished Mirror", 6, 2.0f); // Heavy mirror
            AddJunk("junk_15", "Broken Doll", 4, 0.4f);   // Wooden doll
            AddJunk("junk_16", "Empty Can", 1, 0.1f);     // Tin can
            AddJunk("junk_17", "Old Bones", 3, 0.6f);     // Animal bones
            AddJunk("junk_18", "Rotten Plank", 2, 1.8f);  // Wooden plank
            AddJunk("junk_19", "Rusty Handcuffs", 7, 0.5f); // Metal cuffs
            AddJunk("junk_20", "Leaky Bucket", 5, 1.2f);  // Metal bucket
            AddJunk("junk_21", "Damaged Pocket Watch", 8, 0.2f); // Small watch
            AddJunk("junk_22", "Chipped Plate", 3, 0.4f); // Ceramic plate
            AddJunk("junk_23", "Shattered Lantern", 6, 0.9f); // Metal lantern
            AddJunk("junk_24", "Torn Book", 4, 0.7f);     // Hardcover book
            AddJunk("junk_25", "Dirty Rug", 10, 3.5f);    // Small rug
            AddJunk("junk_26", "Broken Pipe", 5, 1.1f);   // Metal pipe
            AddJunk("junk_27", "Empty Powder Horn", 8, 0.3f); // Animal horn
            AddJunk("junk_28", "Old Horseshoe", 7, 0.4f); // Iron horseshoe
            AddJunk("junk_29", "Rusty Key", 4, 0.1f);     // Large key
            AddJunk("junk_30", "Tattered Sack", 3, 0.2f); // Cloth sack

            // Valuable items (15 items, 50-1000 coins) 
            AddValuable("valuable_1", "Silver Ring", 50, 0.05f);
            AddValuable("valuable_2", "Ivory Figurine", 120, 0.3f);
            AddValuable("valuable_3", "Engraved Bracelet", 200, 0.1f);
            AddValuable("valuable_4", "Golden Chalice", 350, 0.7f);
            AddValuable("valuable_5", "Ornate Necklace", 500, 0.15f);
            AddValuable("valuable_6", "Ancient Coin", 750, 0.02f);
            AddValuable("valuable_7", "Carved Jewelry Box", 400, 1.2f);
            AddValuable("valuable_8", "Enameled Brooch", 250, 0.08f);
            AddValuable("valuable_9", "Silver Scales", 180, 0.5f);
            AddValuable("valuable_10", "Gem-Inlaid Dagger", 600, 0.9f);
            AddValuable("valuable_11", "Crystal Vial", 300, 0.25f);
            AddValuable("valuable_12", "Gilded Mirror", 450, 2.5f);
            AddValuable("valuable_13", "Rare Tome", 550, 1.8f);
            AddValuable("valuable_14", "Precious Gemstone", 800, 0.1f);
            AddValuable("valuable_15", "Imperial Seal", 1000, 0.4f);
            AddValuable("valuable_15", "Coin", 1, 0f);
        }
        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

