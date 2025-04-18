using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DataSystem
{
    public class ContainersRepository : Repository
    {
        private List<ContainerData> _containers;
        private string _jsonFilePath;
        bool _isDirty = false;

        public string JsonFilePath
        {
            get
            {
                _jsonFilePath ??= Path.Combine(Application.persistentDataPath, "Containers.json");
                return _jsonFilePath;
            }
        }


        // ITEMS RELATED
        #region
        internal void RemoveItem(string containerID, string itemID, int amountToRemove)
        {
            if (!TryGetContainerByID(containerID, out ContainerData containerData))
            {
                Debug.LogError($"Container with ID '{containerID}' not found");
                return;
            }

            if (!TryGetItemByID(containerData, itemID, out ItemData itemData))
            {
                Debug.LogWarning($"Item with ID '{itemID}' not found in container '{containerID}'");
                return;
            }

            if (itemData.ItemAmount < amountToRemove)
            {
                Debug.LogError($"Not enough items ({itemData.ItemAmount}) to remove {amountToRemove} of '{itemID}'");
                return;
            }

            if (itemData.ItemAmount > amountToRemove)
                itemData.ItemAmount -= amountToRemove;
            else
                containerData.Items.Remove(itemData);

            _isDirty = true;
        }

        internal void AddItem(string containerID, ItemData itemData)
        {
            if (TryGetContainerByID(containerID, out ContainerData containerData))
            {
                containerData.Items.Add(itemData);
            }

            _isDirty = true;
        }

        private bool TryGetItemByID(ContainerData containerData, string itemID, out ItemData itemData)
        {
            foreach (ItemData item in containerData.Items)
            {
                if (item.ItemID == itemID)
                {
                    itemData = item;
                    return true;
                }
            }

            itemData = null;
            return false;
        }

        public bool TryGetItemDataByConfigKey(ContainerData containerData, string itemConfigKey, out ItemData itemData)
        {
            foreach (ItemData item in containerData.Items)
            {
                if (item.ItemConfigKey == itemConfigKey)
                {
                    itemData = item;
                    return true;
                }
            }

            itemData = null;
            return false;
        }

        #endregion

        // CONTAINERS RELATED
        #region
        public void AddContainer(ContainerData container)
        {
            _containers.Add(container);
            _isDirty = true;
        }

        public bool TryGetContainerByID(string id, out ContainerData containerData)
        {
            if (string.IsNullOrEmpty(id))
            {
                containerData = null;
                return false;
            }

            containerData = _containers.Find(container => container.ContainerID == id);

            return containerData != null;
        }
        #endregion

        // SAVING & LOADING
        #region 
        public override void LoadData()
        {
            _containers = LoadContainersData();
        }

        public List<ContainerData> LoadContainersData()
        {
            if (!File.Exists(JsonFilePath))
            {
                Debug.Log("No save file found, creating new container list");
                return new List<ContainerData>();
            }

            try
            {
                string json = File.ReadAllText(JsonFilePath);
                ContainersDatabaseWrapper wrapper = JsonUtility.FromJson<ContainersDatabaseWrapper>(json);
                return wrapper.Containers ?? new List<ContainerData>();
            }
            catch (Exception e)
            {
                Debug.LogError($"Load failed: {e.Message}");
                return new List<ContainerData>();
            }
        }

        public override void SaveData()
        {
            var wrapper = new ContainersDatabaseWrapper(_containers);

            string json = JsonUtility.ToJson(wrapper, prettyPrint: true);

            try
            {
                File.WriteAllText(JsonFilePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Save failed: {e.Message}");
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

        public override void ResetData()
        {
            if (File.Exists(JsonFilePath))
            {
                File.Delete(JsonFilePath);
                Debug.Log("Containers data reset. Save file deleted.");
            }
            else
            {
                Debug.Log("No containers data save file found to delete.");
            }
        }

        internal bool ItemExists(string containerID, string itemId)
        {
            if (TryGetContainerByID(containerID, out ContainerData containerData))
            {
                return containerData.Items.Any(item => item.ItemID == itemId);
            }
            return false;
        }

        #endregion

        [Serializable]
        public class ContainersDatabaseWrapper
        {
            public List<ContainerData> Containers;

            public ContainersDatabaseWrapper(List<ContainerData> containers)
            {
                Containers = containers;
            }
        }
    }

    [Serializable]
    public class ContainerData
    {
        public string ContainerID;
        public List<ItemData> Items;

        public ContainerData(string id, List<ItemData> items)
        {
            ContainerID = id;
            Items = items;
        }
    }
}

