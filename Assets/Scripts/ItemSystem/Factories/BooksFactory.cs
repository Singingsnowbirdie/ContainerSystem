using System.Collections.Generic;

namespace ItemSystem
{
    public class BooksFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;

            AddBooks();
        }

        private void AddBooks()
        {
            const EItemType IconType = EItemType.Book;
            const float BookWeight = 0.7f;

            void AddBook(string id, string name, int cost)
            {
                AddConfig(new BookConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = BookWeight,
                    BasicCost = cost,
                    ItemType = IconType
                });
            }

            AddBook("book_1", "Blade of the Lunar Mist", 5);
            AddBook("book_2", "Chronicles of the Weeping Stone", 15);
            AddBook("book_3", "Song of the Cursed Stars", 40);
            AddBook("book_4", "Shadow of the Immortal Legion", 100);
            AddBook("book_5", "Blood of the Ancient Dragon", 200);
            AddBook("book_6", "Throne of Time's Bones", 350);
            AddBook("book_7", "Tablets of Dark Flame", 500);
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }

}

