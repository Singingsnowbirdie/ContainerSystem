using System;
using System.Collections.Generic;
using System.Linq;
using VContainer.Unity;

namespace ItemSystem
{
    public class ItemDatabase : IStartable
    {
        private Dictionary<string, ItemConfig> _configs;

        public void Start()
        {
            _configs = new Dictionary<string, ItemConfig>();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            AddFruits();
            AddVegetables();
        }

        private void AddVegetables()
        {
            const bool IsCulinary = true;
            const bool IsAlchemy = false;
            const EFoodType FoodType = EFoodType.Vegetable;
            const float LightVegetableWeight = 0.1f;
            const float HeavyVegetableWeight = 0.2f;

            // Vegetables with weight 0.1
            AddConfig(new FoodConfig("potato", "Potato", LightVegetableWeight, 1, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("carrot", "Carrot", LightVegetableWeight, 1, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("onion", "Onion", LightVegetableWeight, 1, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("tomato", "Tomato", LightVegetableWeight, 4, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("cucumber", "Cucumber", LightVegetableWeight, 1, IsCulinary, IsAlchemy, FoodType));

            // Vegetables with weight 0.2
            AddConfig(new FoodConfig("pumpkin", "Pumpkin", HeavyVegetableWeight, 1, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("zucchini", "Zucchini", HeavyVegetableWeight, 1, IsCulinary, IsAlchemy, FoodType));

            // Vegetables with weight 0.3
            AddConfig(new FoodConfig("cabbage", "Cabbage", 0.3f, 2, IsCulinary, IsAlchemy, FoodType));
        }
        private void AddFruits()
        {
            const float FruitWeight = 0.1f;
            const bool IsCulinary = true;
            const bool IsAlchemy = false;
            const EFoodType FoodType = EFoodType.Fruit;

            AddConfig(new FoodConfig("apple_green", "Green Apple", FruitWeight, 2, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("apple_red", "Red Apple", FruitWeight, 2, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("pear", "Pear", FruitWeight, 2, IsCulinary, IsAlchemy, FoodType));
            AddConfig(new FoodConfig("orange", "Orange", FruitWeight, 5, IsCulinary, IsAlchemy, FoodType));
        }

        public IEnumerable<FoodConfig> GetFruitsAndVegetables()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.Fruit ||
                              food.FoodType == EFoodType.Vegetable);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemID] = config;
        }

        public bool TryGetConfig(string itemID, out ItemConfig config)
        {
            return _configs.TryGetValue(itemID, out config);
        }

        public ItemConfig GetConfig(string itemID)
        {
            if (_configs.TryGetValue(itemID, out var config))
                return config;

            throw new ArgumentException($"Item with ID {itemID} not found");
        }
    }
}

