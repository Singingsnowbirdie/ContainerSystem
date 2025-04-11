using System.Collections.Generic;
using System.Linq;

namespace ItemSystem
{
    public class ItemDatabase
    {
        private readonly Dictionary<string, ItemConfig> _configs = new();

        // Factiries
        private readonly FoodFactory _foodFactory = new FoodFactory();
        private readonly PotionsFactory _potionsFactory = new PotionsFactory();
        private readonly IngredientsFactory _ingredientsFactory = new IngredientsFactory();
        private readonly BooksFactory _booksFactory = new BooksFactory();
        private readonly KeysFactory _keysFactory = new KeysFactory();
        private readonly ArmorFactory _armorFactory = new ArmorFactory();
        private readonly MiscellaneousFactory _miscellaneousFactory = new MiscellaneousFactory();
        private readonly ShieldsFactory _shieldsFactory = new ShieldsFactory();
        private readonly AccessoriesFactory _accessoriesFactory = new AccessoriesFactory();
        private readonly WeaponsFactory _weaponsFactory = new WeaponsFactory();
        private readonly AmmunitionFactory _ammunitionFactory = new AmmunitionFactory();

        public ItemDatabase()
        {
            _foodFactory.AddConfigs(_configs);
            _potionsFactory.AddConfigs(_configs);
            _ingredientsFactory.AddConfigs(_configs);
            _booksFactory.AddConfigs(_configs);
            _keysFactory.AddConfigs(_configs);
            _armorFactory.AddConfigs(_configs);
            _miscellaneousFactory.AddConfigs(_configs);
            _shieldsFactory.AddConfigs(_configs);
            _accessoriesFactory.AddConfigs(_configs);
            _weaponsFactory.AddConfigs(_configs);
            _ammunitionFactory.AddConfigs(_configs);
        }

        public bool TryGetConfig(string itemConfigKey, out ItemConfig config)
        {
            if (_configs.TryGetValue(itemConfigKey, out config))
            {
                return true;
            }
            config = null;
            return false;
        }

        public List<ItemConfig> GetFoodsByType(params EFoodType[] foodTypes)
        {
            return _configs.Values
                .Where(item => item is FoodConfig food && foodTypes.Contains(food.FoodType))
                .ToList();
        }

        public List<ItemConfig> GetPotionsByType(params EPotionType[] potionTypes)
        {
            return _configs.Values
                .Where(item => item is PotionConfig potion && potionTypes.Contains(potion.PotionType))
                .ToList();
        }

        public IEnumerable<PotionConfig> GetAllPotions()
        {
            return _configs.Values.OfType<PotionConfig>();
        }

        public IEnumerable<AccessoryConfig> GetAllAccessories()
        {
            return _configs.Values.OfType<AccessoryConfig>();
        }

        internal List<ItemConfig> GetAllBooks()
        {
            return _configs.Values.OfType<BookConfig>()
                               .Cast<ItemConfig>()
                               .ToList();
        }

        internal List<ItemConfig> GetAllIngredients()
        {
            return _configs.Values.OfType<IngredientConfig>()
                               .Cast<ItemConfig>()
                               .ToList();
        }

        internal List<ItemConfig> GetJunkItems()
        {
            return _configs.Values
                .Where(item => item is JunkConfig)
                .ToList();
        }

        internal List<ItemConfig> GetValuableItems()
        {
            return _configs.Values
                .Where(item => item is ValuableConfig)
                .ToList();
        }

        internal List<ItemConfig> GetArrows(List<int> possibleTiers)
        {
            return _configs.Values
                .Where(item => item is AmmoConfig ammo &&
                              ammo.ItemType == EItemType.Arrow &&
                              possibleTiers.Contains(ammo.Tier))
                .ToList();
        }

        internal List<ItemConfig> GetWarriorEquipment(int tier)
        {
            return _configs.Values
                .Where(item => item is EquipmentConfig equipment &&
                    (equipment.ItemType == EItemType.Sword ||
                     equipment.ItemType == EItemType.TwoHandedSword ||
                     equipment.ItemType == EItemType.HeavyShield ||
                     equipment.ItemType == EItemType.HeavyHelmet ||
                     equipment.ItemType == EItemType.HeavyChest ||
                     equipment.ItemType == EItemType.HeavyLegs ||
                     equipment.ItemType == EItemType.HeavyBoots ||
                     equipment.ItemType == EItemType.HeavyGloves) &&
                    ((EquipmentConfig)item).Tier == tier)
                .ToList();
        }

        internal List<ItemConfig> GetMageEquipment(int tier)
        {
            return _configs.Values
                .Where(item => item is EquipmentConfig equipment &&
                    (equipment.ItemType == EItemType.ClothHelmet ||
                     equipment.ItemType == EItemType.ClothChest ||
                     equipment.ItemType == EItemType.ClothLegs ||
                     equipment.ItemType == EItemType.ClothBoots ||
                     equipment.ItemType == EItemType.ClothGloves ||
                     equipment.ItemType == EItemType.Staff ||
                     equipment.ItemType == EItemType.Dagger) &&
                    ((EquipmentConfig)item).Tier == tier)
                .ToList();
        }

        internal List<ItemConfig> GetRogueEquipment(int tier)
        {
            return _configs.Values
                .Where(item => item is EquipmentConfig equipment &&
                    (equipment.ItemType == EItemType.LightHelmet ||
                     equipment.ItemType == EItemType.LightChest ||
                     equipment.ItemType == EItemType.LightLegs ||
                     equipment.ItemType == EItemType.LightBoots ||
                     equipment.ItemType == EItemType.LightGloves ||
                     equipment.ItemType == EItemType.Sword ||
                     equipment.ItemType == EItemType.Dagger ||
                     equipment.ItemType == EItemType.Bow ||
                     equipment.ItemType == EItemType.LightShield) &&
                    ((EquipmentConfig)item).Tier == tier)
                .ToList();
        }
    }
}

