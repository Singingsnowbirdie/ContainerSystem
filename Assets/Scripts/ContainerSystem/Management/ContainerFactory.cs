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
                EContainerType.ApothecaryBag => GenerateApothecaryBagContents(_itemDatabase.GetAllPotions().ToList(), playerLevel),
                _ => new List<ItemData>()
            };
        }

        private List<ItemData> GenerateApothecaryBagContents(List<PotionConfig> potions, int playerLevel)
        {
            int maxAvailablePotionLevel = CalculateMaxPotionLevel(playerLevel);

            var availablePotions = potions
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
        private int CalculateMaxPotionLevel(int playerLevel)
        {
            // Max player level = 80, max potion level = 5
            return Math.Min(5, (playerLevel / 16) + 1);

            /* Level distribution logic:
             * Levels 1-15:  MaxPotionLevel = 1
             * Levels 16-31: MaxPotionLevel = 2
             * Levels 32-47: MaxPotionLevel = 3
             * Levels 48-63: MaxPotionLevel = 4
             * Levels 64-80: MaxPotionLevel = 5
             */
        }

        private List<ItemData> GenerateRandomFoodItems(List<FoodConfig> itemList)
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

        private List<ItemData> GenerateRandomGroceries(List<FoodConfig> foodConfigs)
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
    }
}
