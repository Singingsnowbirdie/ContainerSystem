using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UniRx;
using UnityEngine;

namespace DataSystem
{
    public class InventoryRepository : IRepository
    {
        private List<ItemData> _items;

        private string _jsonFilePath;

        public string JsonFilePath
        {
            get
            {
                _jsonFilePath ??= Path.Combine(Application.persistentDataPath, "Inventory.json");
                return _jsonFilePath;
            }
        }

        public void LoadData()
        {
            _items = LoadItemsData();
        }

        public List<ItemData> LoadItemsData()
        {
            List<ItemData> inventory = new List<ItemData>();

            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                inventory = JsonUtility.FromJson<InventoryDatabaseWrapper>(json).Items;
            }

            return inventory;
        }

        public void SaveData()
        {
            SaveData(_items);
        }

        public void SaveData(List<ItemData> items)
        {
            if (items == null)
            {
                Debug.LogWarning("Items list is null. Nothing to save.");
                return;
            }

            try
            {
                InventoryDatabaseWrapper wrapper = new InventoryDatabaseWrapper
                {
                    Items = items
                };

                string json = JsonUtility.ToJson(wrapper, true);

                File.WriteAllText(JsonFilePath, json);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to save inventory data: {ex.Message}");
            }
        }

        public bool TryGetItemByConfigKey(string configKey, out ItemData item)
        {
            ItemData existingItem = _items.FirstOrDefault(item => item.ItemConfigKey == configKey);

            if (existingItem != null)
            {
                item = existingItem;
                return true;
            }
            else
            {
                item = null;
                return false;
            }
        }

        public bool TryGetItemByID(string itemId, out ItemData item)
        {
            ItemData existingItem = _items.FirstOrDefault(item => item.ItemID == itemId);

            if (existingItem != null)
            {
                item = existingItem;
                return true;
            }
            else
            {
                item = null;
                return false;
            }
        }

        public void ResetData()
        {
            if (File.Exists(JsonFilePath))
            {
                File.Delete(JsonFilePath);
                Debug.Log("Inventory data reset. Save file deleted.");
            }
            else
            {
                Debug.Log("No inventory data save file found to delete.");
            }
        }

        public void AddItem(ItemData itemData)
        {
            _items.Add(itemData);
        }

        public void RemoveItemById(string itemId)
        {
            ItemData itemToRemove = _items.Find(item => item.ItemID == itemId);
            _items.Remove(itemToRemove);
        }

        public bool ItemExists(string itemId)
        {
            return _items.Any(item => item.ItemID == itemId);
        }

        [Serializable]
        public class InventoryDatabaseWrapper
        {
            public List<ItemData> Items;
        }
    }

    [Serializable]
    public class ItemData
    {
        public string ItemID { get; }
        public string ItemConfigKey { get; }
        public int Quantity { get; set; }

        public ItemData(string itemID, string itemConfigKey, int quantity = 1)
        {
            ItemID = itemID;
            ItemConfigKey = itemConfigKey;
            Quantity = quantity;
        }
    }
}

