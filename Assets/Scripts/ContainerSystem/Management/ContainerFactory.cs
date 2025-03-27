using DataSystem;
using ItemSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ContainerSystem
{
    public class ContainerFactory
    {
        private ItemDatabase _itemDatabase;

        public ContainerFactory(ItemDatabase itemDatabase)
        {
            _itemDatabase = itemDatabase;
        }

        private List<ItemData> GenerateContents(EContainerType type)
        {
            return type switch
            {
                EContainerType.Barrel => GenerateBarrelContents(),
                _ => new List<ItemData>()
            };
        }

        private List<ItemData> GenerateBarrelContents()
        {
            var items = new List<ItemData>();

            var fruitsAndVegetables = _itemDatabase.GetFruitsAndVegetables().ToList();

            if (fruitsAndVegetables.Count == 0)
                return items;

            var weightedFoods = new List<ItemConfig>();
            foreach (FoodConfig food in fruitsAndVegetables)
            {
                int weight = Mathf.Max(1, 10 - food.BasicСost);
                for (int i = 0; i < weight; i++)
                {
                    weightedFoods.Add(food);
                }
            }

            var selectedFood = weightedFoods[Random.Range(0, weightedFoods.Count)];

            int quantity = Random.Range(1, 6);

            items.Add(new ItemData(selectedFood.ItemID, quantity));

            return items;
        }

        public ContainerData CreateNewContainer(string containerID, EContainerType containerType)
        {
            List<ItemData> contents = GenerateContents(containerType);
            return new ContainerData(containerID, contents);
        }
    }
}



