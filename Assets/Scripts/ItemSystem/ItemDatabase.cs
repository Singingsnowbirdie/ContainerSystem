using System.Collections.Generic;
using System.Linq;

namespace ItemSystem
{
    public class ItemDatabase
    {
        private readonly Dictionary<string, ItemConfig> _configs = new();

        // Handlers
        private readonly FoodFactory _foodFactory = new FoodFactory();
        private readonly PotionsFactory _potionsFactory = new PotionsFactory();
        private readonly BooksFactory _booksFactory = new BooksFactory();

        public ItemDatabase()
        {
            _foodFactory.AddConfigs(_configs);
            _potionsFactory.AddConfigs(_configs);
            _booksFactory.AddConfigs(_configs);
        }

        public bool TryGetConfig(string itemConfigKey, out ItemConfig config)
        {
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

