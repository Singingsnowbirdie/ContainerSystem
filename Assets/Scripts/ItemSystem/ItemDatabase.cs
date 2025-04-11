using System.Collections.Generic;
using System.Linq;

namespace ItemSystem
{
    public class ItemDatabase
    {
        private readonly Dictionary<string, ItemConfig> _configs = new();

        // Factiries
        private readonly FoodFactory _foodFactory = new FoodFactory();
        private readonly PotionsFactory _potionsFactory = new PotionsFactory();
        private readonly IngredientsFactory _ingredientsFactory = new IngredientsFactory();
        private readonly BooksFactory _booksFactory = new BooksFactory();
        private readonly KeysFactory _keysFactory = new KeysFactory();
        private readonly ArmorFactory _armorFactory = new ArmorFactory();
        private readonly MiscellaneousFactory _miscellaneousFactory = new MiscellaneousFactory();
        private readonly ShieldsFactory _shieldsFactory = new ShieldsFactory();
        private readonly AccessoriesFactory _accessoriesFactory = new AccessoriesFactory();
        private readonly WeaponsFactory _weaponsFactory = new WeaponsFactory();

        public ItemDatabase()
        {
            _foodFactory.AddConfigs(_configs);
            _potionsFactory.AddConfigs(_configs);
            _ingredientsFactory.AddConfigs(_configs);
            _booksFactory.AddConfigs(_configs);
            _keysFactory.AddConfigs(_configs);
            _armorFactory.AddConfigs(_configs);
            _miscellaneousFactory.AddConfigs(_configs);
            _shieldsFactory.AddConfigs(_configs);
            _accessoriesFactory.AddConfigs(_configs);
            _weaponsFactory.AddConfigs(_configs);
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

        public IEnumerable<PotionConfig> GetAllPotions()
        {
            return _configs.Values.OfType<PotionConfig>();
        }
    }
}

