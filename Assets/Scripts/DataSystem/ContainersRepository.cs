using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DataSystem
{
    public class ContainersRepository : IRepository
    {
        private List<ContainerData> _containers;

        private string _jsonFilePath;

        public string JsonFilePath
        {
            get
            {
                _jsonFilePath ??= Path.Combine(Application.persistentDataPath, "Containers.json");
                return _jsonFilePath;
            }
        }

        public void LoadData()
        {
            _containers = LoadContainersData();
        }

        public List<ContainerData> LoadContainersData()
        {
            List<ContainerData> containers = new List<ContainerData>();

            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                containers = JsonUtility.FromJson<ContainersDatabaseWrapper>(json).Containers;
            }

            return containers;
        }

        public bool TryGetContainerByID(string id, out ContainerData containerData)
        {
            if (string.IsNullOrEmpty(id))
            {
                containerData = null;
                return false;
            }

            containerData = _containers.Find(container => container.Id == id);

            return containerData != null;
        }

        public void ResetData()
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

        public void SaveData()
        {
            SaveData(_containers);
        }

        public void SaveData(List<ContainerData> containers)
        {
            ContainersDatabaseWrapper wrapper = new() { Containers = containers };
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(JsonFilePath, json);
            Debug.Log("Containers data saved to JSON.");
        }

        public void AddContainer(ContainerData container)
        {
            _containers.Add(container);
            SaveData();
        }

        [Serializable]
        private class ContainersDatabaseWrapper
        {
            public List<ContainerData> Containers;
        }
    }

    [Serializable]
    public class ContainerData
    {
        public string Id;
        public List<ItemData> Items;

        public ContainerData(string id, List<ItemData> items)
        {
            Id = id;
            Items = items;
        }
    }
}

