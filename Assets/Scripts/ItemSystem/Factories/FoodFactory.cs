using System.Collections.Generic;

namespace ItemSystem
{
    public class FoodFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
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
                    BasicCost = cost,
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
                    BasicCost = cost,
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
                    BasicCost = cost,
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
                    BasicCost = cost,
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
                    BasicCost = cost,
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
                    BasicCost = cost,
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

            void AddFish(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicCost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Weights
            const float SmallFish = 0.5f;
            const float MediumFish = 0.7f;
            const float LargeFish = 1.0f;

            // River fish
            AddFish("trout", "Trout", 0.6f, 18);
            AddFish("pike", "Pike", 0.8f, 15);
            AddFish("perch", "Perch", SmallFish, 12);
            AddFish("carp", "Carp", MediumFish, 10);
            AddFish("bream", "Bream", 0.6f, 14);
            AddFish("catfish", "Catfish", 0.9f, 16);
            AddFish("zander", "Zander", MediumFish, 22);

            // Sea/valuable fish
            AddFish("salmon", "Salmon", MediumFish, 25);
            AddFish("sturgeon", "Sturgeon", LargeFish, 35);
            AddFish("cod", "Cod", 0.8f, 20);
        }

        private void AddSideDishes()
        {
            const bool IsIngredient = false;
            const EFoodType FoodType = EFoodType.SideDish;
            const EItemType IconType = EItemType.CookedFood;
            const float PortionWeight = 0.3f;

            void AddDish(string id, string name, float weight, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = weight,
                    BasicCost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Porridge and bread (2 ingredients: grain + salt)
            AddDish("wheat_porridge", "Wheat Porridge", PortionWeight, 3);
            AddDish("rye_flatbread", "Rye Flatbread", 0.25f, 4);
            AddDish("barley_porridge", "Barley Porridge", PortionWeight, 2);
            AddDish("buckwheat_porridge", "Buckwheat Porridge", PortionWeight, 5);
            AddDish("boiled_rice", "Boiled Rice", PortionWeight, 5);
            AddDish("millet_porridge", "Millet Porridge", PortionWeight, 3);
            AddDish("wheat_bread", "Wheat Bread", 0.4f, 5);

            // Vegetable dishes (2 ingredients: vegetable + salt)
            AddDish("stewed_cabbage", "Stewed Cabbage", PortionWeight, 2);
            AddDish("boiled_potato", "Boiled Potato", PortionWeight, 2);
            AddDish("carrot_puree", "Carrot Puree", PortionWeight, 2);
            AddDish("pumpkin_puree", "Pumpkin Puree", PortionWeight, 3);
        }

        private void AddCookedMeats()
        {
            const bool IsIngredient = false;
            const EItemType IconType = EItemType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const float PortionWeight = 0.25f;

            void AddDish(string id, string name, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PortionWeight,
                    BasicCost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // Meat dishes
            AddDish("cooked_chicken", "Fried Chicken", 7);
            AddDish("cooked_goat_meat", "Fried Goat Meat", 8);
            AddDish("cooked_pork", "Fried Pork", 9);
            AddDish("cooked_rabbit", "Fried Rabbit", 10);
            AddDish("cooked_lamb", "Fried Lamb", 12);
            AddDish("cooked_duck", "Fried Duck", 13);
            AddDish("cooked_beef", "Fried Beef", 14);
            AddDish("cooked_horse_meat", "Fried Horse Meat", 16);
            AddDish("cooked_venison", "Fried Venison", 20);
            AddDish("cooked_goose", "Fried Goose", 15);

            // Fish dishes
            AddDish("fried_carp", "Fried Carp", 5);
            AddDish("fried_perch", "Baked Perch", 6);
            AddDish("fried_pike", "Fried Pike", 11);
            AddDish("steamed_salmon", "Steamed Salmon", 17);
            AddDish("fried_trout", "Fried Trout", 18);
        }

        private void AddAdvancedMeatCourses()
        {
            const float PortionWeight = 0.25f;
            const EItemType IconType = EItemType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const bool IsIngredient = false;

            void AddMeal(string meatType, string seasoning, int cost)
            {
                string id = $"{meatType.ToLower()}_{seasoning.ToLower()}";
                string name = $"{meatType} with {seasoning}";

                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PortionWeight,
                    BasicCost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // 3 ingredients (meat + salt + seasoning)
            AddMeal("Chicken", "Rosemary", 10);
            AddMeal("Goat Meat", "Cumin", 12);
            AddMeal("Pork", "Mustard", 14);
            AddMeal("Lamb", "Garlic", 16);
            AddMeal("Rabbit", "Lingonberry", 18);
            AddMeal("Duck", "Orange", 20);
            AddMeal("Beef", "Juniper", 21);
            AddMeal("Goose", "Apple", 22);
            AddMeal("Horse Meat", "Pepper", 23);
            AddMeal("Venison", "Lingonberry", 25);
        }

        private void AddAdvancedFishCourses()
        {
            const float PortionWeight = 0.25f;
            const EItemType IconType = EItemType.CookedFood;
            const EFoodType FoodType = EFoodType.MainCourse;
            const bool IsIngredient = false;

            void AddFishCourse(string fish, string preparation, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = $"{fish.ToLower()}_{preparation.Split(' ')[0].ToLower()}",
                    ItemDefaultName = $"{fish} {preparation}",
                    Weight = PortionWeight,
                    BasicCost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // 4 ingredients (fish + salt + 2 accompaniments)
            AddFishCourse("Perch", "with Herbs", 15);
            AddFishCourse("Trout", "with Lemon Butter", 17);
            AddFishCourse("Pike", "in Cream Sauce", 18);
            AddFishCourse("Catfish", "with Paprika", 18);
            AddFishCourse("Salmon", "with Dill Crust", 20);
            AddFishCourse("Cod", "with Mustard", 20);
            AddFishCourse("Carp", "with Saffron", 22);
            AddFishCourse("Bream", "in Wine Sauce", 24);
            AddFishCourse("Zander", "with Ginger", 26);
            AddFishCourse("Sturgeon", "with Tarragon", 30);
        }

        private void AddSoups()
        {
            const bool IsIngredient = false;
            const EFoodType FoodType = EFoodType.Soup;
            const EItemType IconType = EItemType.CookedFood;
            const float BowlWeight = 0.35f;

            void AddSoup(string id, string name, int cost)
            {
                AddConfig(new FoodConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = BowlWeight,
                    BasicCost = cost,
                    ItemType = IconType,
                    FoodType = FoodType,
                    IsIngredient = IsIngredient
                });
            }

            // 6 ingredients
            AddSoup("pumpkin_cream_soup", "Pumpkin Cream Soup", 20);
            AddSoup("chicken_noodle_soup", "Chicken Noodle Soup", 22);

            // 7 ingredients
            AddSoup("seasonal_vegetable_soup", "Seasonal Vegetable Soup", 24);
            AddSoup("mushroom_cream_soup", "Mushroom Cream Soup", 25);
            AddSoup("pea_smoked_soup", "Pea Soup with Smoked Meat", 27);

            // 8+ ingredients
            AddSoup("ukha", "Ukha", 30);
            AddSoup("borscht", "Borscht", 32);
            AddSoup("meat_solyanka", "Meat Solyanka", 35);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

