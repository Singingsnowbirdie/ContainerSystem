using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ItemSystem
{
    public class ItemDatabase
    {
        private readonly Dictionary<string, ItemConfig> _configs = new();
        private readonly FoodConfigsHandler _foodConfigsHandler = new FoodConfigsHandler();

        public ItemDatabase()
        {
            _foodConfigsHandler.AddFoodConfigs(_configs);
        }

        public bool TryGetConfig(string itemConfigKey, out ItemConfig config)
        {
            Debug.Log($"itemConfigKey = {itemConfigKey}");

            if (_configs.TryGetValue(itemConfigKey, out config))
            {
                return true;
            }
            config = null;
            return false;
        }

        public IEnumerable<FoodConfig> GetFoodsByType(params EFoodType[] foodTypes)
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => foodTypes.Contains(food.FoodType));
        }
    }
}

