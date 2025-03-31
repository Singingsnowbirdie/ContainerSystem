using System;
using System.Collections.Generic;
using System.Linq;

namespace ItemSystem
{
    public class ItemDatabase
    {
        private readonly Dictionary<string, ItemConfig> _configs = new();

        public ItemDatabase()
        {
            AddFruits();
            AddVegetables();
            AddDrinks();
            AddGrocery();
            AddRawMeats();
            AddRawFish();
            AddCookedMeats();
            AddAdvancedMeatCourses();
            AddAdvancedFishCourses();
            AddGrains();
            AddSideDishes();
            AddSoups();
        }

        private void AddVegetables()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Vegetable;
            const EItemIconType IconType = EItemIconType.RawPlant;

            // Vegetables with weight 0.1
            const float LightVegetableWeight = 0.1f;
            AddConfig(new FoodConfig("potato", "Potato", LightVegetableWeight, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("carrot", "Carrot", LightVegetableWeight, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("onion", "Onion", LightVegetableWeight, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("tomato", "Tomato", LightVegetableWeight, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cucumber", "Cucumber", LightVegetableWeight, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("mushroom", "Mushroom", LightVegetableWeight, 3, IconType, FoodType, IsIngredient));

            // Vegetables with weight 0.2
            const float HeavyVegetableWeight = 0.2f;
            AddConfig(new FoodConfig("pumpkin", "Pumpkin", HeavyVegetableWeight, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("zucchini", "Zucchini", HeavyVegetableWeight, 1, IconType, FoodType, IsIngredient));

            // Vegetables with weight 0.3
            AddConfig(new FoodConfig("beet", "Beetroot", 0.3f, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cabbage", "Cabbage", 0.3f, 2, IconType, FoodType, IsIngredient));

        }

        private void AddFruits()
        {
            const float FruitWeight = 0.1f;
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Fruit;
            const EItemIconType IconType = EItemIconType.RawPlant;

            AddConfig(new FoodConfig("apple_green", "Green Apple", FruitWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("apple_red", "Red Apple", FruitWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pear", "Pear", FruitWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("lemon", "Lemon", 0.15f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("orange", "Orange", FruitWeight, 5, IconType, FoodType, IsIngredient));
        }

        private void AddGrains()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Grain;
            const EItemIconType IconType = EItemIconType.RawPlant;

            // Basic cereals in bags (~1 kg)
            AddConfig(new FoodConfig("peas", "Dried Peas", 0.1f, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("rye", "Rye Grains", 1.0f, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("oat", "Oat Grains", 1.0f, 3, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("barley", "Barley", 1.0f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("wheat", "Wheat Grains", 1.0f, 5, IconType, FoodType, IsIngredient));

            // More expensive/rare cereals
            AddConfig(new FoodConfig("millet", "Millet", 0.7f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("buckwheat", "Buckwheat", 0.8f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("rice", "Rice", 0.9f, 10, IconType, FoodType, IsIngredient));

            // Processed cereals (less weight)
            AddConfig(new FoodConfig("flour_wheat", "Wheat Flour", 0.5f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("flour_rye", "Rye Flour", 0.5f, 5, IconType, FoodType, IsIngredient));
        }

        private void AddDrinks()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Drink;
            const EItemIconType IconType = EItemIconType.Drink;

            // Basic drinks
            AddConfig(new FoodConfig("water_bottle", "Bottle of Water", 1.0f, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("milk_jug", "Jug of Milk", 1.2f, 3, IconType, FoodType, IsIngredient));

            // Young wines
            AddConfig(new FoodConfig("young_red_wine", "Young Red Wine", 1.1f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("young_white_wine", "Young White Wine", 1.1f, 7, IconType, FoodType, IsIngredient));

            // Mature wines
            AddConfig(new FoodConfig("mature_red_wine", "Mature Red Wine", 1.1f, 15, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("mature_white_wine", "Mature White Wine", 1.1f, 12, IconType, FoodType, IsIngredient));

            // Aged wines
            AddConfig(new FoodConfig("aged_red_wine", "Aged Red Wine", 1.1f, 25, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("aged_white_wine", "Aged White Wine", 1.1f, 20, IconType, FoodType, IsIngredient));

            // Beers
            AddConfig(new FoodConfig("wheat_beer", "Wheat Beer", 1.0f, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("seasonal_ale", "Seasonal Ale", 1.0f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("old_ale", "Old Ale", 1.0f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("dark_ale", "Dark Ale", 1.0f, 7, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("stout", "Stout", 1.1f, 9, IconType, FoodType, IsIngredient));
        }

        private void AddGrocery()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Grocery;
            const EItemIconType IconType = EItemIconType.Grocery;

            // Сheapest spices
            AddConfig(new FoodConfig("garlic", "Garlic", 0.25f, 1, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("greens", "Fresh Greens", 0.1f, 1, IconType, FoodType, IsIngredient));

            // Basic spices
            AddConfig(new FoodConfig("salt", "Salt", 0.2f, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("bay_leaf", "Bay Leaf", 0.02f, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("sugar", "Sugar", 0.3f, 3, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pickle", "Pickled Cucumber", 0.1f, 3, IconType, FoodType, IsIngredient));

            // Piquant additions
            AddConfig(new FoodConfig("sour_cream", "Sour Cream", 0.2f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("rosemary", "Rosemary", 0.15f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cumin", "Cumin", 0.1f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pepper", "Pepper", 0.2f, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("mustard", "Mustard", 0.2f, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("juniper_berries", "Juniper Berries", 0.15f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("lingonberry", "Lingonberry", 0.15f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("capers", "Capers", 0.05f, 6, IconType, FoodType, IsIngredient));

            // Expensive/rare spices
            AddConfig(new FoodConfig("ginger", "Ginger Root", 0.1f, 7, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("honey", "Honey", 0.5f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cinnamon", "Cinnamon", 0.2f, 10, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("olives", "Olives", 0.1f, 10, IconType, FoodType, IsIngredient));

            // Oils and premium spices
            AddConfig(new FoodConfig("butter", "Butter", 0.25f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("vegetable_oil", "Vegetable Oil", 0.3f, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("tarragon", "Tarragon", 0.1f, 7, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("saffron", "Saffron", 0.01f, 25, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("paprika", "Paprika", 0.15f, 12, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("soy_sauce", "Soy Sauce", 0.2f, 15, IconType, FoodType, IsIngredient));

            // Cheeses
            AddConfig(new FoodConfig("cheese_young", "Young Cheese", 0.25f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cheese_aged", "Aged Cheese", 0.2f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cheese_sheep", "Sheep Cheese", 0.22f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cheese_goat", "Goat Cheese", 0.18f, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cheese_hard", "Hard Cheese", 0.3f, 10, IconType, FoodType, IsIngredient));

            // Meat
            AddConfig(new FoodConfig("smoked_pork_ribs", "Smoked Pork Ribs", 0.5f, 12, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("ham", "Ham", 0.2f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("sausage", "Sausage", 0.2f, 7, IconType, FoodType, IsIngredient));
        }
        private void AddRawMeats()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.RawMeat;
            const EItemIconType IconType = EItemIconType.RawMeat;

            AddConfig(new FoodConfig("chicken", "Chicken", 0.8f, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("goat_meat", "Goat Meat", 0.7f, 7, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pork", "Pork", 0.9f, 7, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("rabbit", "Rabbit", 0.6f, 10, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("lamb", "Lamb", 0.8f, 12, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("duck", "Duck", 0.7f, 14, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("beef", "Beef", 1.0f, 18, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("horse_meat", "Horse Meat", 0.9f, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("venison", "Venison", 0.8f, 22, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("goose", "Goose", 0.9f, 16, IconType, FoodType, IsIngredient));
        }

        private void AddRawFish()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.RawFish;
            const EItemIconType IconType = EItemIconType.RawFish;

            AddConfig(new FoodConfig("salmon", "Salmon", 0.7f, 25, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("trout", "Trout", 0.6f, 18, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pike", "Pike", 0.8f, 15, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("sturgeon", "Sturgeon", 1.0f, 35, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("perch", "Perch", 0.5f, 12, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("carp", "Carp", 0.7f, 10, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("bream", "Bream", 0.6f, 14, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("catfish", "Catfish", 0.9f, 16, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cod", "Cod", 0.8f, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("zander", "Zander", 0.7f, 22, IconType, FoodType, IsIngredient));
        }

        private void AddSideDishes()
        {
            const bool IsIngredient = false;
            const EFoodType FoodType = EFoodType.SideDish;
            const EItemIconType IconType = EItemIconType.CookedFood;
            const float PortionWeight = 0.3f;

            // 2 ingredients (main grain + salt)
            AddConfig(new FoodConfig("wheat_porridge", "Wheat Porridge", PortionWeight, 3, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("rye_flatbread", "Rye Flatbread", 0.25f, 4, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("barley_porridge", "Barley Porridge", PortionWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("buckwheat_porridge", "Buckwheat Porridge", PortionWeight, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("boiled_rice", "Boiled Rice", PortionWeight, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("millet_porridge", "Millet Porridge", PortionWeight, 3, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("wheat_bread", "Wheat Bread", 0.4f, 5, IconType, FoodType, IsIngredient));

            // 2 ingredients (vegetable + salt)
            AddConfig(new FoodConfig("stewed_cabbage", "Stewed Cabbage", PortionWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("boiled_potato", "Boiled Potato", PortionWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("carrot_puree", "Carrot Puree", PortionWeight, 2, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pumpkin_puree", "Pumpkin Puree", PortionWeight, 3, IconType, FoodType, IsIngredient));
        }

        private void AddCookedMeats()
        {
            const bool IsIngredient = false;
            const EItemIconType IconType = EItemIconType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const float PortionWeight = 0.25f;

            // Meat dishes
            AddConfig(new FoodConfig("cooked_chicken", "Fried Chicken", PortionWeight, 7, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_goat_meat", "Fried Goat Meat", PortionWeight, 8, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_pork", "Fried Pork", PortionWeight, 9, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_rabbit", "Fried Rabbit", PortionWeight, 10, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_lamb", "Fried Lamb", PortionWeight, 12, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_duck", "Fried Duck", PortionWeight, 13, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_beef", "Fried Beef", PortionWeight, 14, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_horse_meat", "Fried Horse Meat", PortionWeight, 16, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_venison", "Fried Venison", PortionWeight, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cooked_goose", "Fried Goose", PortionWeight, 15, IconType, FoodType, IsIngredient));

            // Fish dishes
            AddConfig(new FoodConfig("fried_carp", "Fried Carp", PortionWeight, 5, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("fried_perch", "Baked Perch", PortionWeight, 6, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("fried_pike", "Fried Pike", PortionWeight, 11, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("steamed_salmon", "Steamed Salmon", PortionWeight, 17, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("fried_trout", "Fried Trout", PortionWeight, 18, IconType, FoodType, IsIngredient));
        }

        private void AddAdvancedMeatCourses()
        {
            const float PortionWeight = 0.25f;
            const EItemIconType IconType = EItemIconType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const bool IsIngredient = false;

            // 3 ingredients (meat + salt + one more)
            AddConfig(new FoodConfig("chicken_rosemary", "Chicken with Rosemary", PortionWeight, 10, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("goat_cumin", "Goat Meat with Cumin", PortionWeight, 12, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pork_mustard", "Pork with Mustard", PortionWeight, 14, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("lamb_garlic", "Lamb with Garlic", PortionWeight, 16, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("rabbit_lingonberry", "Rabbit with Lingonberry", PortionWeight, 18, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("duck_orange", "Duck with Orange", PortionWeight, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("beef_juniper", "Beef with Juniper", PortionWeight, 21, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("goose_apple", "Goose with Apple", PortionWeight, 22, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("horse_pepper", "Horse Meat with Pepper", PortionWeight, 23, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("venison_lingonberry", "Venison with Lingonberry", PortionWeight, 25, IconType, FoodType, IsIngredient));
        }

        private void AddAdvancedFishCourses()
        {
            const float PortionWeight = 0.25f;
            const EItemIconType IconType = EItemIconType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const bool IsIngredient = false;

            // 4 ingredients (fish + salt + 2 more)
            AddConfig(new FoodConfig("perch_herbs", "Perch with Herbs", PortionWeight, 15, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("trout_lemon", "Trout with Lemon Butter", PortionWeight, 17, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pike_cream", "Pike in Cream Sauce", PortionWeight, 18, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("catfish_paprika", "Catfish with Paprika", PortionWeight, 18, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("salmon_dill", "Salmon with Dill Crust", PortionWeight, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("cod_mustard", "Cod with Mustard", PortionWeight, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("carp_saffron", "Carp with Saffron", PortionWeight, 22, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("bream_wine", "Bream in Wine Sauce", PortionWeight, 24, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("zander_ginger", "Zander with Ginger", PortionWeight, 26, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("sturgeon_tarragon", "Sturgeon with Tarragon", PortionWeight, 30, IconType, FoodType, IsIngredient));
        }

        private void AddSoups()
        {
            const bool IsIngredient = false;
            const EFoodType FoodType = EFoodType.Soup;
            const EItemIconType IconType = EItemIconType.CookedFood;
            const float BowlWeight = 0.35f;

            // 6 ingredients
            AddConfig(new FoodConfig("pumpkin_cream_soup", "Pumpkin Cream Soup", BowlWeight, 20, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("chicken_noodle_soup", "Chicken Noodle Soup", BowlWeight, 22, IconType, FoodType, IsIngredient));

            // 7 ingredients
            AddConfig(new FoodConfig("seasonal_vegetable_soup", "Seasonal Vegetable Soup", BowlWeight, 24, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("mushroom_cream_soup", "Mushroom Cream Soup", BowlWeight, 25, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("pea_smoked_soup", "Pea Soup with Smoked Meat", BowlWeight, 27, IconType, FoodType, IsIngredient));

            // 8+ ingredients
            AddConfig(new FoodConfig("ukha", "Ukha", BowlWeight, 30, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("borscht", "Borscht", BowlWeight, 32, IconType, FoodType, IsIngredient));
            AddConfig(new FoodConfig("meat_solyanka", "Meat Solyanka", BowlWeight, 35, IconType, FoodType, IsIngredient));
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
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

        public IEnumerable<FoodConfig> GetFruitsAndVegetables()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.Fruit ||
                              food.FoodType == EFoodType.Vegetable);
        }

        public IEnumerable<FoodConfig> GetGrains()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.Grain);
        }

        public IEnumerable<FoodConfig> GetBeverages()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.Drink);
        }

        public IEnumerable<FoodConfig> GetMeats()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.RawMeat);
        }

        public IEnumerable<FoodConfig> GetFish()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.RawFish);
        }
        
        public IEnumerable<FoodConfig> GetGroceries()
        {
            return _configs.Values
                .OfType<FoodConfig>()
                .Where(food => food.FoodType == EFoodType.Grocery);
        }
    }
}

