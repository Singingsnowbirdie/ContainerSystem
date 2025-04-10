using ItemSystem;
using System;
using System.Collections.Generic;
using UniRx;

namespace UI
{
    public class ItemUIModel : UIModel
    {
        private List<EContainerFilter> _suitableFilters;

        // Immutable properties
        public string UniqueID { get; init; }
        public ItemConfig ItemConfig { get; init; }
        public bool CanBeEquipped => ItemConfig.CanBeEquipped;

        // Reactive properties 
        public ReactiveProperty<EItemType> ItemTypeIcon { get; init; } = new();
        public ReactiveProperty<string> ItemType { get; } = new();
        public ReactiveProperty<string> ItemName { get; } = new();
        public ReactiveProperty<float> ItemWeight { get; } = new();
        public ReactiveProperty<int> ItemCost { get; init; } = new();
        public ReactiveProperty<string> EquipmentClass { get; } = new();
        public ReactiveProperty<bool> IsSelected { get; } = new();
        public ReactiveProperty<EContainerFilter> SelectedFilter { get; init; }

        // Subjects
        public ISubject<string> SelectItem { get; } = new Subject<string>();

        private static readonly Dictionary<Type, Action<List<EContainerFilter>, ItemConfig>> _filterRules = new()
        {
            { typeof(FoodConfig), (list, config) => {
                list.Add(EContainerFilter.Consumables);
                if (((FoodConfig)config).IsIngredient)
                    list.Add(EContainerFilter.Ingredients);
            }},
            { typeof(IngredientConfig), (list, _) => list.Add(EContainerFilter.Ingredients) },
            { typeof(PotionConfig), (list, _) => list.Add(EContainerFilter.Consumables) },
            { typeof(WeaponConfig), (list, _) => list.Add(EContainerFilter.Weapons) },
            { typeof(ArmorConfig), (list, _) => list.Add(EContainerFilter.Armor) },
            { typeof(BookConfig), (list, _) => list.Add(EContainerFilter.Books) }
        };

        public List<EContainerFilter> SuitableFilters
        {
            get
            {
                if (_suitableFilters != null)
                    return _suitableFilters;

                _suitableFilters = new List<EContainerFilter> { EContainerFilter.All };

                if (ItemConfig != null)
                {
                    var configType = ItemConfig.GetType();
                    foreach (var rule in _filterRules)
                    {
                        if (rule.Key.IsAssignableFrom(configType))
                        {
                            rule.Value(_suitableFilters, ItemConfig);
                        }
                    }
                }

                return _suitableFilters;
            }
        }
    }
}