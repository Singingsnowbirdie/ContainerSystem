using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace ItemSystem
{
    public class ItemDatabase : IStartable
    {
        private Dictionary<string, ItemConfig> _configs;

        public void Start()
        {
            _configs = new Dictionary<string, ItemConfig>();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            AddConfig(new ItemConfig(
                "salt",
                "Salt",
                0.1f,
                2,
                false,  // IsFood
                true,   // IsCulinary
                false  // IsAlchemy
                ));
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemID] = config;
        }

        public bool TryGetConfig(string itemID, out ItemConfig config)
        {
            return _configs.TryGetValue(itemID, out config);
        }

        public ItemConfig GetConfig(string itemID)
        {
            if (_configs.TryGetValue(itemID, out var config))
                return config;

            throw new ArgumentException($"Item with ID {itemID} not found");
        }
    }
}

