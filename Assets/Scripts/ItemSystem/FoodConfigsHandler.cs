using System.Collections.Generic;

namespace ItemSystem
{
    public class FoodConfigsHandler
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddFoodConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;

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

        private void AddFruits()
        {
            const float FruitWeight = 0.1f;
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Fruit;
            const EItemType IconType = EItemType.RawPlant;

            void AddFruit(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicСost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            AddFruit("apple_green", "Green Apple", FruitWeight, 2);
            AddFruit("apple_red", "Red Apple", FruitWeight, 2);
            AddFruit("pear", "Pear", FruitWeight, 2);
            AddFruit("lemon", "Lemon", 0.15f, 4);
            AddFruit("orange", "Orange", FruitWeight, 5);
        }

        private void AddVegetables()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Vegetable;
            const EItemType IconType = EItemType.RawPlant;

            void AddVegetable(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicСost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Light vegetables (0.1 kg)
            const float LightVegetableWeight = 0.1f;
            AddVegetable("potato", "Potato", LightVegetableWeight, 1);
            AddVegetable("carrot", "Carrot", LightVegetableWeight, 1);
            AddVegetable("onion", "Onion", LightVegetableWeight, 1);
            AddVegetable("tomato", "Tomato", LightVegetableWeight, 4);
            AddVegetable("cucumber", "Cucumber", LightVegetableWeight, 1);
            AddVegetable("mushroom", "Mushroom", LightVegetableWeight, 3);

            // Heavy vegetables (0.2 kg)
            const float HeavyVegetableWeight = 0.2f;
            AddVegetable("pumpkin", "Pumpkin", HeavyVegetableWeight, 1);
            AddVegetable("zucchini", "Zucchini", HeavyVegetableWeight, 1);

            // Very heavy vegetables (0.3 kg)
            AddVegetable("beet", "Beetroot", 0.3f, 2);
            AddVegetable("cabbage", "Cabbage", 0.3f, 2);
        }
        private void AddDrinks()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Drink;
            const EItemType IconType = EItemType.Drink;

            void AddDrink(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicСost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Basic drinks
            AddDrink("water_bottle", "Bottle of Water", 1.0f, 1);
            AddDrink("milk_jug", "Jug of Milk", 1.2f, 3);

            // Young wines
            AddDrink("young_red_wine", "Young Red Wine", 1.1f, 8);
            AddDrink("young_white_wine", "Young White Wine", 1.1f, 7);

            // Mature wines
            AddDrink("mature_red_wine", "Mature Red Wine", 1.1f, 15);
            AddDrink("mature_white_wine", "Mature White Wine", 1.1f, 12);

            // Aged wines
            AddDrink("aged_red_wine", "Aged Red Wine", 1.1f, 25);
            AddDrink("aged_white_wine", "Aged White Wine", 1.1f, 20);

            // Beers
            AddDrink("wheat_beer", "Wheat Beer", 1.0f, 5);
            AddDrink("seasonal_ale", "Seasonal Ale", 1.0f, 6);
            AddDrink("old_ale", "Old Ale", 1.0f, 8);
            AddDrink("dark_ale", "Dark Ale", 1.0f, 7);
            AddDrink("stout", "Stout", 1.1f, 9);
        }

        private void AddGrains()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Grain;
            const EItemType IconType = EItemType.RawPlant;

            void AddGrain(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicСost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Weights
            const float StandardBagWeight = 1.0f;
            const float SmallBagWeight = 0.1f;
            const float ProcessedWeight = 0.5f;

            // Basic cereals in bags (~1 kg)
            AddGrain("peas", "Dried Peas", SmallBagWeight, 2);
            AddGrain("rye", "Rye Grains", StandardBagWeight, 2);
            AddGrain("oat", "Oat Grains", StandardBagWeight, 3);
            AddGrain("barley", "Barley", StandardBagWeight, 4);
            AddGrain("wheat", "Wheat Grains", StandardBagWeight, 5);

            // More expensive/rare cereals
            AddGrain("millet", "Millet", 0.7f, 6);
            AddGrain("buckwheat", "Buckwheat", 0.8f, 8);
            AddGrain("rice", "Rice", 0.9f, 10);

            // Processed cereals (less weight)
            AddGrain("flour_wheat", "Wheat Flour", ProcessedWeight, 8);
            AddGrain("flour_rye", "Rye Flour", ProcessedWeight, 5);
        }

        private void AddGrocery()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.Grocery;
            const EItemType IconType = EItemType.Grocery;

            void AddItem(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicСost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Weights
            const float TinyWeight = 0.01f;    
            const float SmallWeight = 0.1f;    
            const float MediumWeight = 0.2f;   
            const float LargeWeight = 0.5f;

            // 1. Cheap Spices and Essentials
            AddItem("garlic", "Garlic", 0.25f, 1);
            AddItem("greens", "Fresh Greens", SmallWeight, 1);
            AddItem("salt", "Salt", MediumWeight, 2);
            AddItem("bay_leaf", "Bay Leaf", 0.02f, 2);
            AddItem("sugar", "Sugar", 0.3f, 3);
            AddItem("pickle", "Pickled Cucumber", SmallWeight, 3);

            // 2. Spicy additives
            AddItem("sour_cream", "Sour Cream", MediumWeight, 4);
            AddItem("rosemary", "Rosemary", 0.15f, 4);
            AddItem("cumin", "Cumin", SmallWeight, 4);
            AddItem("pepper", "Pepper", MediumWeight, 5);
            AddItem("mustard", "Mustard", MediumWeight, 5);
            AddItem("juniper_berries", "Juniper Berries", 0.15f, 6);
            AddItem("lingonberry", "Lingonberry", 0.15f, 6);
            AddItem("capers", "Capers", 0.05f, 6);

            // 3. Expensive/rare spices
            AddItem("ginger", "Ginger Root", SmallWeight, 7);
            AddItem("honey", "Honey", LargeWeight, 8);
            AddItem("cinnamon", "Cinnamon", MediumWeight, 10);
            AddItem("olives", "Olives", SmallWeight, 10);

            // 4. Oils and premium spices
            AddItem("butter", "Butter", 0.25f, 6);
            AddItem("vegetable_oil", "Vegetable Oil", 0.3f, 5);
            AddItem("tarragon", "Tarragon", SmallWeight, 7);
            AddItem("saffron", "Saffron", TinyWeight, 25);
            AddItem("paprika", "Paprika", 0.15f, 12);
            AddItem("soy_sauce", "Soy Sauce", MediumWeight, 15);

            // 5. Cheeses
            AddItem("cheese_young", "Young Cheese", 0.25f, 4);
            AddItem("cheese_aged", "Aged Cheese", MediumWeight, 6);
            AddItem("cheese_sheep", "Sheep Cheese", 0.22f, 6);
            AddItem("cheese_goat", "Goat Cheese", 0.18f, 6);
            AddItem("cheese_hard", "Hard Cheese", 0.3f, 10);

            // 6. Meat products
            AddItem("smoked_pork_ribs", "Smoked Pork Ribs", LargeWeight, 12);
            AddItem("ham", "Ham", MediumWeight, 8);
            AddItem("sausage", "Sausage", MediumWeight, 7);
        }

        private void AddRawMeats()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.RawMeat;
            const EItemType IconType = EItemType.RawMeat;

            void AddMeat(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicСost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Weights
            const float SmallPortion = 0.6f;   
            const float MediumPortion = 0.8f;  
            const float LargePortion = 1.0f;

            // Poultry meat
            AddMeat("chicken", "Chicken", MediumPortion, 8);
            AddMeat("duck", "Duck", 0.7f, 14);
            AddMeat("goose", "Goose", 0.9f, 16);

            // Livestock
            AddMeat("goat_meat", "Goat Meat", 0.7f, 7);
            AddMeat("pork", "Pork", 0.9f, 7);
            AddMeat("lamb", "Lamb", MediumPortion, 12);
            AddMeat("beef", "Beef", LargePortion, 18);
            AddMeat("horse_meat", "Horse Meat", 0.9f, 20);

            // Game
            AddMeat("rabbit", "Rabbit", SmallPortion, 10);
            AddMeat("venison", "Venison", MediumPortion, 22);
        }

        private void AddRawFish()
        {
            const bool IsIngredient = true;
            const EFoodType FoodType = EFoodType.RawFish;
            const EItemType IconType = EItemType.RawFish;

            //AddConfig(new FoodConfig("salmon", "Salmon", 0.7f, 25, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("trout", "Trout", 0.6f, 18, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("pike", "Pike", 0.8f, 15, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("sturgeon", "Sturgeon", 1.0f, 35, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("perch", "Perch", 0.5f, 12, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("carp", "Carp", 0.7f, 10, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("bream", "Bream", 0.6f, 14, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("catfish", "Catfish", 0.9f, 16, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cod", "Cod", 0.8f, 20, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("zander", "Zander", 0.7f, 22, IconType, FoodType, IsIngredient));
        }

        private void AddSideDishes()
        {
            const bool IsIngredient = false;
            const EFoodType FoodType = EFoodType.SideDish;
            const EItemType IconType = EItemType.CookedFood;
            const float PortionWeight = 0.3f;

            //// 2 ingredients (main grain + salt)
            //AddConfig(new FoodConfig("wheat_porridge", "Wheat Porridge", PortionWeight, 3, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("rye_flatbread", "Rye Flatbread", 0.25f, 4, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("barley_porridge", "Barley Porridge", PortionWeight, 2, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("buckwheat_porridge", "Buckwheat Porridge", PortionWeight, 5, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("boiled_rice", "Boiled Rice", PortionWeight, 5, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("millet_porridge", "Millet Porridge", PortionWeight, 3, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("wheat_bread", "Wheat Bread", 0.4f, 5, IconType, FoodType, IsIngredient));

            //// 2 ingredients (vegetable + salt)
            //AddConfig(new FoodConfig("stewed_cabbage", "Stewed Cabbage", PortionWeight, 2, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("boiled_potato", "Boiled Potato", PortionWeight, 2, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("carrot_puree", "Carrot Puree", PortionWeight, 2, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("pumpkin_puree", "Pumpkin Puree", PortionWeight, 3, IconType, FoodType, IsIngredient));
        }

        private void AddCookedMeats()
        {
            const bool IsIngredient = false;
            const EItemType IconType = EItemType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const float PortionWeight = 0.25f;

            //// Meat dishes
            //AddConfig(new FoodConfig("cooked_chicken", "Fried Chicken", PortionWeight, 7, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_goat_meat", "Fried Goat Meat", PortionWeight, 8, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_pork", "Fried Pork", PortionWeight, 9, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_rabbit", "Fried Rabbit", PortionWeight, 10, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_lamb", "Fried Lamb", PortionWeight, 12, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_duck", "Fried Duck", PortionWeight, 13, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_beef", "Fried Beef", PortionWeight, 14, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_horse_meat", "Fried Horse Meat", PortionWeight, 16, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_venison", "Fried Venison", PortionWeight, 20, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cooked_goose", "Fried Goose", PortionWeight, 15, IconType, FoodType, IsIngredient));

            //// Fish dishes
            //AddConfig(new FoodConfig("fried_carp", "Fried Carp", PortionWeight, 5, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("fried_perch", "Baked Perch", PortionWeight, 6, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("fried_pike", "Fried Pike", PortionWeight, 11, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("steamed_salmon", "Steamed Salmon", PortionWeight, 17, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("fried_trout", "Fried Trout", PortionWeight, 18, IconType, FoodType, IsIngredient));
        }

        private void AddAdvancedMeatCourses()
        {
            const float PortionWeight = 0.25f;
            const EItemType IconType = EItemType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const bool IsIngredient = false;

            //// 3 ingredients (meat + salt + one more)
            //AddConfig(new FoodConfig("chicken_rosemary", "Chicken with Rosemary", PortionWeight, 10, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("goat_cumin", "Goat Meat with Cumin", PortionWeight, 12, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("pork_mustard", "Pork with Mustard", PortionWeight, 14, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("lamb_garlic", "Lamb with Garlic", PortionWeight, 16, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("rabbit_lingonberry", "Rabbit with Lingonberry", PortionWeight, 18, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("duck_orange", "Duck with Orange", PortionWeight, 20, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("beef_juniper", "Beef with Juniper", PortionWeight, 21, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("goose_apple", "Goose with Apple", PortionWeight, 22, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("horse_pepper", "Horse Meat with Pepper", PortionWeight, 23, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("venison_lingonberry", "Venison with Lingonberry", PortionWeight, 25, IconType, FoodType, IsIngredient));
        }

        private void AddAdvancedFishCourses()
        {
            const float PortionWeight = 0.25f;
            const EItemType IconType = EItemType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const bool IsIngredient = false;

            //// 4 ingredients (fish + salt + 2 more)
            //AddConfig(new FoodConfig("perch_herbs", "Perch with Herbs", PortionWeight, 15, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("trout_lemon", "Trout with Lemon Butter", PortionWeight, 17, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("pike_cream", "Pike in Cream Sauce", PortionWeight, 18, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("catfish_paprika", "Catfish with Paprika", PortionWeight, 18, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("salmon_dill", "Salmon with Dill Crust", PortionWeight, 20, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("cod_mustard", "Cod with Mustard", PortionWeight, 20, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("carp_saffron", "Carp with Saffron", PortionWeight, 22, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("bream_wine", "Bream in Wine Sauce", PortionWeight, 24, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("zander_ginger", "Zander with Ginger", PortionWeight, 26, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("sturgeon_tarragon", "Sturgeon with Tarragon", PortionWeight, 30, IconType, FoodType, IsIngredient));
        }

        private void AddSoups()
        {
            const bool IsIngredient = false;
            const EFoodType FoodType = EFoodType.Soup;
            const EItemType IconType = EItemType.CookedFood;
            const float BowlWeight = 0.35f;

            //// 6 ingredients
            //AddConfig(new FoodConfig("pumpkin_cream_soup", "Pumpkin Cream Soup", BowlWeight, 20, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("chicken_noodle_soup", "Chicken Noodle Soup", BowlWeight, 22, IconType, FoodType, IsIngredient));

            //// 7 ingredients
            //AddConfig(new FoodConfig("seasonal_vegetable_soup", "Seasonal Vegetable Soup", BowlWeight, 24, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("mushroom_cream_soup", "Mushroom Cream Soup", BowlWeight, 25, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("pea_smoked_soup", "Pea Soup with Smoked Meat", BowlWeight, 27, IconType, FoodType, IsIngredient));

            //// 8+ ingredients
            //AddConfig(new FoodConfig("ukha", "Ukha", BowlWeight, 30, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("borscht", "Borscht", BowlWeight, 32, IconType, FoodType, IsIngredient));
            //AddConfig(new FoodConfig("meat_solyanka", "Meat Solyanka", BowlWeight, 35, IconType, FoodType, IsIngredient));
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

