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

        public void SaveContainers()
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

        public void AddContainer(ContainerData container)
        {
            _containers.Add(container);
            SaveContainers();
        }

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

