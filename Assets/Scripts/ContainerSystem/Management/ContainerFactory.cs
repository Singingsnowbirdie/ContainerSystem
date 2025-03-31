using DataSystem;
using ItemSystem;
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

        public ContainerData CreateNewContainer(string containerID, EContainerType containerType)
        {
            _usedIDs.Clear();
            List<ItemData> contents = GenerateContents(containerType);
            return new ContainerData(containerID, contents);
        }

        private List<ItemData> GenerateContents(EContainerType type)
        {
            return type switch
            {
                EContainerType.Barrel => GenerateBarrelContents(),
                EContainerType.Bag => GenerateBagContents(),
                EContainerType.BeverageСrate => GenerateBeverageContents(),
                EContainerType.ButcherCrate => GenerateMeatContents(),
                EContainerType.FishCrate => GenerateFishContents(),
                EContainerType.GroceriesCrate => GenerateGroceriesContents(),
                _ => new List<ItemData>()
            };
        }

        private List<ItemData> GenerateRandomFoodItems(List<FoodConfig> itemList)
        {
            var items = new List<ItemData>();

            if (itemList.Count == 0)
                return items;

            var weightedItems = new List<ItemConfig>();
            foreach (var item in itemList)
            {
                int weight = Mathf.Max(1, 10 - item.BasicСost);
                for (int i = 0; i < weight; i++)
                {
                    weightedItems.Add(item);
                }
            }

            var selectedItem = weightedItems[Random.Range(0, weightedItems.Count)];
            items.Add(new ItemData(CreateUniqueItemID(), selectedItem.ItemConfigKey, Random.Range(1, 6)));

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
        new ItemData(CreateUniqueItemID(), "salt", Random.Range(1, 6))
    };

            if (foodConfigs.Count == 0)
                return items;

            var weightedItems = new List<ItemConfig>();
            foreach (var item in foodConfigs)
            {
                int weight = Mathf.Max(1, 10 - item.BasicСost);
                for (int i = 0; i < weight; i++)
                {
                    weightedItems.Add(item);
                }
            }

            int additionalItemsCount = Random.Range(1, 4);
            var selectedItems = new HashSet<string>();
            int attempts = 0;
            const int MaxAttempts = 100;

            while (selectedItems.Count < additionalItemsCount && attempts < MaxAttempts)
            {
                attempts++;
                if (weightedItems.Count == 0)
                    break;

                var selectedItem = weightedItems[Random.Range(0, weightedItems.Count)];

                if (!selectedItems.Contains(selectedItem.ItemConfigKey))
                {
                    selectedItems.Add(selectedItem.ItemConfigKey);
                    items.Add(new ItemData(CreateUniqueItemID(), selectedItem.ItemConfigKey, Random.Range(1, 6)));
                }
            }

            return items;
        }
        private List<ItemData> GenerateBagContents()
        {
            return GenerateRandomFoodItems(_itemDatabase.GetGrains().ToList());
        }

        private List<ItemData> GenerateBarrelContents()
        {
            return GenerateRandomFoodItems(_itemDatabase.GetFruitsAndVegetables().ToList());
        }

        private List<ItemData> GenerateBeverageContents()
        {
            return GenerateRandomFoodItems(_itemDatabase.GetBeverages().ToList());
        }

        private List<ItemData> GenerateMeatContents()
        {
            return GenerateRandomFoodItems(_itemDatabase.GetMeats().ToList());
        }

        private List<ItemData> GenerateFishContents()
        {
            return GenerateRandomFoodItems(_itemDatabase.GetFish().ToList());
        }

        private List<ItemData> GenerateGroceriesContents()
        {
            return GenerateRandomGroceries(_itemDatabase.GetGroceries().ToList());
        }
    }
}



