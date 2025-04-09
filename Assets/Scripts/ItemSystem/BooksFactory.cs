using System.Collections.Generic;

namespace ItemSystem
{
    public class BooksFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;

        }
    }
}

