using System.Collections.Generic;

namespace ItemSystem
{
    public class IngredientsFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;

            AddAlchemyIngredients();
        }

        private void AddAlchemyIngredients()
        {
            // Base ingredients (H/M/S)
            void AddBaseIngredient(string id, string name, int level, int cost)
            {
                AddConfig(new IngredientConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = 0.1f, // Standard weight for ingredients
                    BasicCost = cost,
                    ItemType = EItemType.Ingredient,
                    IngredientLevel = level,
                });
            }

            // Special ingredients (R/B/G)
            void AddSpecialIngredient(string id, string name, int level, int cost)
            {
                AddConfig(new IngredientConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = 0.15f, // Slightly heavier due to magical nature
                    BasicCost = cost,
                    ItemType = EItemType.Ingredient,
                    IngredientLevel = level,
                });
            }

            //=== Base Ingredients (Health/Mana/Stamina) ===//
            // Tier I
            AddBaseIngredient("ing_h_1", "Iron Mushroom", 1, 5);
            AddBaseIngredient("ing_m_1", "Moon Dust", 1, 5);
            AddBaseIngredient("ing_s_1", "Sun Berry", 1, 5);

            // Tier II
            AddBaseIngredient("ing_h_2", "Life Root", 2, 10);
            AddBaseIngredient("ing_m_2", "Star Shard", 2, 10);
            AddBaseIngredient("ing_s_2", "Thunder Root", 2, 10);

            // Tier III
            AddBaseIngredient("ing_h_3", "Phoenix Heart", 3, 20);
            AddBaseIngredient("ing_m_3", "Arcane Crystal", 3, 20);
            AddBaseIngredient("ing_s_3", "Dragon Claw", 3, 20);

            //=== Special Ingredients (Restoration/Boost/Regeneration) ===//
            // Tier I
            AddSpecialIngredient("ing_r_1", "Healing Moss", 1, 5);
            AddSpecialIngredient("ing_b_1", "Bone Powder", 1, 5);
            AddSpecialIngredient("ing_g_1", "Healing Dew", 1, 5);

            // Tier II
            AddSpecialIngredient("ing_r_2", "Fern Flower", 2, 10);
            AddSpecialIngredient("ing_b_2", "Adamantite Shard", 2, 10);
            AddSpecialIngredient("ing_g_2", "Ethereal Lichen", 2, 10);

            // Tier III
            AddSpecialIngredient("ing_r_3", "Angel's Tear", 3, 20);
            AddSpecialIngredient("ing_b_3", "Dragon Scale", 3, 20);
            AddSpecialIngredient("ing_g_3", "Sands of Time", 3, 20);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

