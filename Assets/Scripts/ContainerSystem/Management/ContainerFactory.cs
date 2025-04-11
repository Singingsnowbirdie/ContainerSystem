using DataSystem;
using ItemSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ContainerSystem
{
    public class ContainerFactory
    {
        private readonly ItemDatabase _itemDatabase;
        private readonly HashSet<string> _usedIDs = new HashSet<string>();

        public ContainerFactory(ItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }

        public ContainerData CreateNewContainer(string containerID, EContainerType containerType, int playerLevel)
        {
            _usedIDs.Clear();
            List<ItemData> contents = GenerateContents(containerType, playerLevel);
            return new ContainerData(containerID, contents);
        }

        private List<ItemData> GenerateContents(EContainerType type, int playerLevel)
        {
            return type switch
            {
                EContainerType.Barrel => GenerateRandomFoodItems(_itemDatabase.GetFoodsByType(EFoodType.Fruit, EFoodType.Vegetable).ToList()),
                EContainerType.Bag => GenerateRandomFoodItems(_itemDatabase.GetFoodsByType(EFoodType.Grain).ToList()),
                EContainerType.BeverageСrate => GenerateRandomFoodItems(_itemDatabase.GetFoodsByType(EFoodType.Drink).ToList()),
                EContainerType.ButcherCrate => GenerateRandomFoodItems(_itemDatabase.GetFoodsByType(EFoodType.RawMeat).ToList()),
                EContainerType.FishCrate => GenerateRandomFoodItems(_itemDatabase.GetFoodsByType(EFoodType.RawFish).ToList()),
                EContainerType.GroceriesCrate => GenerateRandomGroceries(_itemDatabase.GetFoodsByType(EFoodType.Grocery).ToList()),
                EContainerType.ApothecaryBag => GenerateApothecaryBagContents(playerLevel),
                EContainerType.JewelerBag => GenerateJewelerBagContents(_itemDatabase.GetItemsByType<AccessoryConfig>(), playerLevel),
                EContainerType.Bookshelf => GenerateBooks(_itemDatabase.GetItemsByType<BookConfig>(), 5, 15),
                EContainerType.EquipmentСhest => GenerateEquipmentChestContent(playerLevel),
                EContainerType.MageChest => GenerateMageChestContent(playerLevel),
                EContainerType.RogueChest => GenerateRogueChestContent(playerLevel),
                EContainerType.WarriorChest => GenerateWarriorChestContent(playerLevel),
                _ => new List<ItemData>()
            };
        }

        // GENERATE CONTENTS
        #region 
        private List<ItemData> GenerateEquipmentChestContent(int playerLevel)
        {
            var random = new System.Random();

            // Determine the class of the chest owner (warrior, mage, rogue)
            int chestClass = random.Next(0, 3);

            return chestClass switch
            {
                0 => GenerateWarriorChestContent(playerLevel),
                1 => GenerateMageChestContent(playerLevel),
                _ => GenerateRogueChestContent(playerLevel),
            };
        }

        private List<ItemData> GenerateMageChestContent(int playerLevel)
        {
            var random = new System.Random();
            var chestContents = new List<ItemData>();

            // 1. Get equipment for the mage (taking into account the level)
            List<ItemConfig> equipment = _itemDatabase.GetMageEquipment(CalculateMaxTier(playerLevel));

            // 2. Choose 2-3 pieces of equipment
            if (equipment.Count > 0)
            {
                var equipmentWeights = equipment.Select(e => 1000f / (e.BasicCost + 1)).ToArray();
                float equipmentTotalWeight = equipmentWeights.Sum();
                int equipmentCount = random.Next(2, 4);

                AddRandomItems(chestContents, equipment, equipmentWeights, equipmentTotalWeight, equipmentCount);
            }

            // 3. Add food and drinks
            AddFoodAndDrinks(random, chestContents);

            // 4. Potion Possible (50% chance)
            if (random.NextDouble() < 0.5)
            {
                List<ItemConfig> potions = _itemDatabase.GetPotionsByType(EPotionType.HealthPotion, EPotionType.ManaPotion);
                AddSuitablePotions(playerLevel, chestContents, potions);
            }

            // 5. Personal belongings (junk)
            AddPersonalBelongings(random, chestContents);

            // 7. Possible books or ingredients (50% chance)
            if (random.NextDouble() < 0.5)
            {
                // 50% on the book, 50% on the ingredients
                if (random.NextDouble() < 0.5)
                {
                    chestContents.AddRange(GenerateBooks(_itemDatabase.GetItemsByType<BookConfig>(), 1, 2));
                }
                else
                {
                    chestContents.AddRange(GenerateIngredients(_itemDatabase.GetItemsByType<IngredientConfig>(), 1, 5));
                }
            }

            return chestContents;
        }

        private List<ItemData> GenerateRogueChestContent(int playerLevel)
        {
            var random = new System.Random();
            var chestContents = new List<ItemData>();

            // 1. Get equipment for the rogue (taking into account the level)
            List<ItemConfig> equipment = _itemDatabase.GetRogueEquipment(CalculateMaxTier(playerLevel));

            // 2. Choose 2-3 pieces of equipment
            if (equipment.Count > 0)
            {
                var equipmentWeights = equipment.Select(e => 1000f / (e.BasicCost + 1)).ToArray();
                float equipmentTotalWeight = equipmentWeights.Sum();
                int equipmentCount = random.Next(2, 4);

                AddRandomItems(chestContents, equipment, equipmentWeights, equipmentTotalWeight, equipmentCount);
            }

            // 3. Add food and drinks
            AddFoodAndDrinks(random, chestContents);

            // 4. Potion Possible (50% chance)
            if (random.NextDouble() < 0.5)
            {
                List<ItemConfig> potions = _itemDatabase.GetPotionsByType(EPotionType.HealthPotion, EPotionType.Poison);
                AddSuitablePotions(playerLevel, chestContents, potions);
            }

            // 5. Personal belongings (junk)
            AddPersonalBelongings(random, chestContents);

            // 6. Possible arrows (50% chance)
            if (random.NextDouble() < 0.5)
            {
                int arrowTier = CalculateArrowTier(playerLevel);

                // We get arrows of acceptable tiers (current, +1 and -1)
                var possibleTiers = new List<int> { arrowTier };
                if (arrowTier > 1) possibleTiers.Add(arrowTier - 1);
                if (arrowTier < 10) possibleTiers.Add(arrowTier + 1);

                // We receive all suitable arrows
                List<ItemConfig> arrows = _itemDatabase.GetArrows(possibleTiers);

                if (arrows.Count > 0)
                {
                    // Select a random arrow type
                    var selectedArrow = arrows[random.Next(arrows.Count)];

                    // We determine the quantity (10-20 pieces)
                    int arrowCount = random.Next(10, 21);

                    // Add to container
                    chestContents.Add(new ItemData(
                        CreateUniqueItemID(),
                        selectedArrow.ItemConfigKey,
                        arrowCount
                    ));
                }
            }

            return chestContents;
        }

        private List<ItemData> GenerateWarriorChestContent(int playerLevel)
        {
            var random = new System.Random();
            var chestContents = new List<ItemData>();

            // 1. Get equipment for the warrior (taking into account the level)
            List<ItemConfig> equipment = _itemDatabase.GetWarriorEquipment(CalculateMaxTier(playerLevel));

            // 2. Choose 2-3 pieces of equipment
            if (equipment.Count > 0)
            {
                var equipmentWeights = equipment.Select(e => 1000f / (e.BasicCost + 1)).ToArray();
                float equipmentTotalWeight = equipmentWeights.Sum();
                int equipmentCount = random.Next(2, 4);

                AddRandomItems(chestContents, equipment, equipmentWeights, equipmentTotalWeight, equipmentCount);
            }

            // 3. Add food and drinks
            AddFoodAndDrinks(random, chestContents);

            // 4. Potion Possible (50% chance)
            if (random.NextDouble() < 0.5)
            {
                List<ItemConfig> potions = _itemDatabase.GetPotionsByType(EPotionType.HealthPotion, EPotionType.StaminaPotion);
                AddSuitablePotions(playerLevel, chestContents, potions);
            }

            // 5. Personal belongings (junk)
            AddPersonalBelongings(random, chestContents);

            // 6. Possible trophy (20% chance)
            if (random.NextDouble() < 0.2)
            {
                List<ItemConfig> valuableItems = _itemDatabase.GetItemsByType<ValuableConfig>();

                if (valuableItems.Count > 0)
                {
                    var valuableWeights = valuableItems.Select(v => 1000f / (v.BasicCost + 1)).ToArray();
                    float valuableTotalWeight = valuableWeights.Sum();

                    AddRandomItems(chestContents, valuableItems, valuableWeights, valuableTotalWeight, 1);
                }
            }

            return chestContents;
        }

        private List<ItemData> GenerateBooks(List<ItemConfig> bookConfigs, int minAmount, int maxAmount)
        {
            if (bookConfigs.Count == 0)
                return new List<ItemData>();

            // Weight is inversely proportional to cost (expensive books are less common)
            var weights = bookConfigs.Select(b => 1000f / b.BasicCost).ToArray();
            float totalWeight = weights.Sum();

            var shelfContents = new List<ItemData>();
            var random = new System.Random();

            // We use the passed parameters to determine the number of books
            int bookCount = random.Next(minAmount, maxAmount + 1);

            for (int i = 0; i < bookCount; i++)
            {
                float randomValue = (float)random.NextDouble() * totalWeight;
                float currentSum = 0;

                for (int j = 0; j < bookConfigs.Count; j++)
                {
                    currentSum += weights[j];
                    if (randomValue <= currentSum)
                    {
                        var uniqueID = CreateUniqueItemID();
                        shelfContents.Add(new ItemData(uniqueID, bookConfigs[j].ItemConfigKey, 1));
                        break;
                    }
                }
            }

            return shelfContents;
        }

        private List<ItemData> GenerateIngredients(List<ItemConfig> itemConfigs, int minAmount, int maxAmount)
        {
            if (itemConfigs.Count == 0)
                return new List<ItemData>();

            // Weight is inversely proportional to cost (expensive ingredients are less common)
            var weights = itemConfigs.Select(i => 1000f / i.BasicCost).ToArray();
            float totalWeight = weights.Sum();

            var ingredientContents = new List<ItemData>();
            var random = new System.Random();

            // Generate 3-6 different types of ingredients 
            int ingredientTypesCount = random.Next(3, 7);

            for (int i = 0; i < ingredientTypesCount; i++)
            {
                float randomValue = (float)random.NextDouble() * totalWeight;
                float currentSum = 0;

                for (int j = 0; j < itemConfigs.Count; j++)
                {
                    currentSum += weights[j];
                    if (randomValue <= currentSum)
                    {
                        // For ingredients, we generate a random amount (within a given range)
                        int amount = random.Next(minAmount, maxAmount + 1);
                        var uniqueID = CreateUniqueItemID();
                        ingredientContents.Add(new ItemData(uniqueID, itemConfigs[j].ItemConfigKey, amount));
                        break;
                    }
                }
            }

            return ingredientContents;
        }

        private List<ItemData> GenerateRandomFoodItems(List<ItemConfig> itemList)
        {
            var items = new List<ItemData>();

            if (itemList.Count == 0)
                return items;

            var weightedItems = new List<ItemConfig>();
            foreach (var item in itemList)
            {
                int weight = Mathf.Max(1, 10 - item.BasicCost);
                for (int i = 0; i < weight; i++)
                {
                    weightedItems.Add(item);
                }
            }

            var selectedItem = weightedItems[UnityEngine.Random.Range(0, weightedItems.Count)];

            var uniqueID = CreateUniqueItemID();
            int amount = UnityEngine.Random.Range(1, 6);
            items.Add(new ItemData(uniqueID, selectedItem.ItemConfigKey, amount));

            return items;
        }

        private List<ItemData> GenerateRandomGroceries(List<ItemConfig> foodConfigs)
        {
            var items = new List<ItemData>
    {
        new ItemData(CreateUniqueItemID(), "salt", UnityEngine.Random.Range(1, 6))
    };

            if (foodConfigs.Count == 0)
                return items;

            var weightedItems = new List<ItemConfig>();
            foreach (var item in foodConfigs)
            {
                int weight = Mathf.Max(1, 10 - item.BasicCost);
                for (int i = 0; i < weight; i++)
                {
                    weightedItems.Add(item);
                }
            }

            int additionalItemsCount = UnityEngine.Random.Range(1, 4);
            var selectedItems = new HashSet<string>();
            int attempts = 0;
            const int MaxAttempts = 100;

            while (selectedItems.Count < additionalItemsCount && attempts < MaxAttempts)
            {
                attempts++;
                if (weightedItems.Count == 0)
                    break;

                var selectedItem = weightedItems[UnityEngine.Random.Range(0, weightedItems.Count)];

                if (!selectedItems.Contains(selectedItem.ItemConfigKey))
                {
                    selectedItems.Add(selectedItem.ItemConfigKey);
                    items.Add(new ItemData(CreateUniqueItemID(), selectedItem.ItemConfigKey, UnityEngine.Random.Range(1, 6)));
                }
            }

            return items;
        }

        private List<ItemData> GenerateApothecaryBagContents(int playerLevel)
        {
            List<ItemConfig> potions = _itemDatabase.GetItemsByType<PotionConfig>();

            int maxAvailablePotionLevel = CalculateMaxTier(playerLevel);

            var availablePotions = potions
                .OfType<PotionConfig>()  
                .Where(p => p.PotionLevel <= maxAvailablePotionLevel)
                .ToList();

            if (availablePotions.Count == 0)
                return new List<ItemData>();

            var weights = availablePotions.Select(p => 1000f / p.BasicCost).ToArray();
            float totalWeight = weights.Sum();

            var bagContents = new List<ItemData>();
            var random = new System.Random();
            int potionCount = random.Next(1, 3);

            for (int i = 0; i < potionCount; i++)
            {
                float randomValue = (float)random.NextDouble() * totalWeight;
                float currentSum = 0;

                for (int j = 0; j < availablePotions.Count; j++)
                {
                    currentSum += weights[j];
                    if (randomValue <= currentSum)
                    {
                        var uniqueID = CreateUniqueItemID();
                        bagContents.Add(new ItemData(uniqueID, availablePotions[j].ItemConfigKey, 1));

                        break;
                    }
                }
            }

            return bagContents;
        }

        private List<ItemData> GenerateJewelerBagContents(List<ItemConfig> accessoryConfigs, int playerLevel)
        {
            int maxAvailableTier = CalculateMaxTier(playerLevel);

            var availableAccessories = accessoryConfigs
                .Cast<AccessoryConfig>()  
                .Where(a => a.Tier <= maxAvailableTier)
                .ToList();

            if (availableAccessories.Count == 0)
                return new List<ItemData>();

            // Weight is inversely proportional to cost (more expensive accessories are less common)
            var weights = availableAccessories.Select(a => 1000f / a.BasicCost).ToArray();
            float totalWeight = weights.Sum();

            var bagContents = new List<ItemData>();
            var random = new System.Random();
            int itemCount = random.Next(1, 3); // 1-2 accessories

            for (int i = 0; i < itemCount; i++)
            {
                float randomValue = (float)random.NextDouble() * totalWeight;
                float currentSum = 0;

                for (int j = 0; j < availableAccessories.Count; j++)
                {
                    currentSum += weights[j];
                    if (randomValue <= currentSum)
                    {
                        var uniqueID = CreateUniqueItemID();
                        bagContents.Add(new ItemData(uniqueID, availableAccessories[j].ItemConfigKey, 1));
                        break;
                    }
                }
            }

            return bagContents;
        }
        #endregion

        // CALCULATIONS
        #region CALCULATIONS
        private int CalculateMaxTier(int playerLevel)
        {
            const int MaxTier = 5;
            const int LevelsPerTier = 16;

            return Math.Min(MaxTier, (playerLevel / LevelsPerTier) + 1);

            /* Level distribution logic:
             * Levels 1-15:  Tier = 1
             * Levels 16-31: Tier = 2
             * Levels 32-47: Tier = 3
             * Levels 48-63: Tier = 4
             * Levels 64-80: Tier = 5
             */
        }

        private int CalculateArrowTier(int playerLevel)
        {
            // Max player level = 80, max arrow tier = 10
            return Math.Min(10, (playerLevel / 8) + 1);

            /* Level distribution logic:
             * Levels 1-7:   Tier = 1
             * Levels 8-15:  Tier = 2
             * Levels 16-23: Tier = 3
             * Levels 24-31: Tier = 4
             * Levels 32-39: Tier = 5
             * Levels 40-47: Tier = 6
             * Levels 48-55: Tier = 7
             * Levels 56-63: Tier = 8
             * Levels 64-71: Tier = 9
             * Levels 72-80: Tier = 10
             */
        }

        #endregion

        // ADDING METHODS
        #region ADDING METHODS
        private void AddFoodAndDrinks(System.Random random, List<ItemData> chestContents)
        {
            List<ItemConfig> foodAndDrinks = _itemDatabase.GetFoodsByType(EFoodType.Fruit, EFoodType.SideDish, EFoodType.Drink,
                EFoodType.MainCourse, EFoodType.Soup).ToList();

            if (foodAndDrinks.Count > 0)
            {
                var foodWeights = foodAndDrinks.Select(f => 1000f / (f.BasicCost + 1)).ToArray();
                float foodTotalWeight = foodWeights.Sum();
                int foodCount = random.Next(1, 3);

                AddRandomItems(chestContents, foodAndDrinks, foodWeights, foodTotalWeight, foodCount);
            }
        }

        private void AddRandomItems(List<ItemData> container, List<ItemConfig> items, float[] weights, float totalWeight, int count)
        {
            var random = new System.Random();

            for (int i = 0; i < count && items.Count > 0; i++)
            {
                ItemConfig selectedItem = null;

                if (weights != null)
                {
                    // Selection based on weights
                    float randomValue = (float)random.NextDouble() * totalWeight;
                    float currentSum = 0;

                    for (int j = 0; j < items.Count; j++)
                    {
                        currentSum += weights[j];
                        if (randomValue <= currentSum)
                        {
                            selectedItem = items[j];
                            break;
                        }
                    }
                }
                else
                {
                    // Uniform random selection
                    selectedItem = items[random.Next(items.Count)];
                }

                var uniqueID = CreateUniqueItemID();

                container.Add(new ItemData(uniqueID, selectedItem.ItemConfigKey, 1));
            }
        }

        private void AddSuitablePotions(int playerLevel, List<ItemData> chestContents, List<ItemConfig> potions)
        {
            int requiredTier = CalculateMaxTier(playerLevel);

            List<PotionConfig> filteredPotions = potions
                .OfType<PotionConfig>()
                .Where(potion => potion.PotionLevel == requiredTier)
                .ToList();

            if (filteredPotions != null && filteredPotions.Count > 0)
            {
                System.Random rand = new System.Random();

                var randomPotion = filteredPotions[rand.Next(filteredPotions.Count)];

                var potionItem = new ItemData(
                   itemID: CreateUniqueItemID(),
                    itemConfigKey: randomPotion.ItemConfigKey,
                    quantity: 1
                );

                chestContents.Add(potionItem);
            }
        }

        private void AddPersonalBelongings(System.Random random, List<ItemData> chestContents)
        {
            var junkItems = _itemDatabase.GetItemsByType<JunkConfig>();

            if (junkItems.Count > 0)
            {
                int junkCount = random.Next(1, 3);
                AddRandomItems(chestContents, junkItems, null, junkItems.Count, junkCount); // Equal chances for junk
            }
        }

        #endregion

        private string CreateUniqueItemID()
        {
            const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new System.Random();
            string newID;

            do
            {
                var stringChars = new char[8];
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = CHARS[random.Next(CHARS.Length)];
                }
                newID = new string(stringChars);
            }
            while (_usedIDs.Contains(newID));

            _usedIDs.Add(newID);
            return newID;
        }
    }
}
