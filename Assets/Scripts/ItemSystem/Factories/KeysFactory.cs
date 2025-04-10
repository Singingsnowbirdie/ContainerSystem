using System.Collections.Generic;

namespace ItemSystem
{
    public class KeysFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;
            AddKeys();
        }

        private void AddKeys()
        {
            const EItemType IconType = EItemType.Key;

            void AddKey(string id, string name)
            {
                AddConfig(new KeyConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    ItemType = IconType
                });
            }

            AddKey("key_1", "Rusty Iron Key");
            AddKey("key_2", "Tarnished Bronze Key");
            AddKey("key_3", "Ornate Silver Key");
            AddKey("key_4", "Gilded Golden Key");
            AddKey("key_5", "Ancient Skeleton Key");
            AddKey("key_6", "Enchanted Crystal Key");
            AddKey("key_7", "Forgotten Dungeon Key");
            AddKey("key_8", "Royal Palace Key");
            AddKey("key_9", "Arcane Vault Key");
            AddKey("key_10", "Master Key of Secrets");
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

