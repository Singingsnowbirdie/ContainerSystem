using ItemSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UniRx;
using UnityEngine;

namespace DataSystem
{

    public class InventoryRepository : Repository
    {
        private List<ItemData> _items;
        private string _jsonFilePath;
        private bool _isDirty;

        public string JsonFilePath
        {
            get
            {
                _jsonFilePath ??= Path.Combine(Application.persistentDataPath, "Inventory.json");
                return _jsonFilePath;
            }
        }

        public List<ItemData> Items { get => _items; }

        // SAVING & LOADING
        #region
        public override void LoadData()
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

        public override void SaveData()
        {
            SaveData(Items);
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

        public override void ResetData()
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

        public override void OnTimeToSave()
        {
            if (_isDirty)
            {
                SaveData();
                _isDirty = false;
            }
        }
        #endregion

        // ITEMS RELATED
        #region
        public void AddItem(ItemData itemData)
        {
            Items.Add(itemData);
            _isDirty = true;
        }

        public void RemoveItemById(string itemId)
        {
            ItemData itemToRemove = Items.Find(item => item.ItemID == itemId);
            Items.Remove(itemToRemove);
            _isDirty = true;
        }

        public bool ItemExists(string itemId)
        {
            return Items.Any(item => item.ItemID == itemId);
        }

        public bool TryGetItemByConfigKey(string configKey, out ItemData item)
        {
            ItemData existingItem = Items.FirstOrDefault(item => item.ItemConfigKey == configKey);

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
            ItemData existingItem = Items.FirstOrDefault(item => item.ItemID == itemId);

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

        #endregion

        [Serializable]
        public class InventoryDatabaseWrapper
        {
            public List<ItemData> Items;
        }
    }

    [Serializable]
    public class ItemData
    {
        public string ItemID;
        public string ItemConfigKey;
        public int ItemAmount;
        public EItemType ItemType;

        public ItemData(string itemID, EItemType itemType, string itemConfigKey, int itemAmount = 1)
        {
            ItemID = itemID;
            ItemType = itemType;
            ItemConfigKey = itemConfigKey;
            ItemAmount = itemAmount;
        }
    }
}

