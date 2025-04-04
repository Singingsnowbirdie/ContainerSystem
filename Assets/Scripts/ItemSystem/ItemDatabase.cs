using System.Collections.Generic;
using System.Linq;

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

        public bool TryGetConfig(string itemID, out ItemConfig config)
        {
            return _configs.TryGetValue(itemID, out config);
        }

        public IEnumerable<FoodConfig> GetFoodsByType(params EFoodType[] foodTypes)
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => foodTypes.Contains(food.FoodType));
        }
    }
}

