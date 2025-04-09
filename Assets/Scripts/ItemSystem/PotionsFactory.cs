using System.Collections.Generic;

namespace ItemSystem
{
    public class PotionsFactory
    {
        private Dictionary<string, ItemConfig> _configs;

        internal void AddConfigs(Dictionary<string, ItemConfig> configsDict)
        {
            _configs = configsDict;

            // Restoration Potions
            AddStaminaRecoveryPotions();
            AddHealthRecoveryPotions();
            AddManaRecoveryPotions();

            // Potions that speed up replenishment
            AddStaminaBoostPotions();
            AddHealthBoostPotions();
            AddManaBoostPotions();

            // Potions that increase max amount
            AddHealthIncreasePotions();
            AddStaminaIncreasePotions();
            AddManaIncreasePotions();

            // Poisons
            AddPoisons();

        }

        private void AddManaBoostPotions()
        {
            const EItemType IconType = EItemType.ManaPotion;
            const float PotionWeight = 0.3f;

            void AddPotion(string id, string name, int level, int cost, float boostMultiplier, float duration)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Mana,
                    BoostMultiplier = boostMultiplier,
                    EffectDuration = duration
                });
            }

            // Mana regeneration boost potions (tiers 1-5)
            AddPotion("mana_boost_1", "Minor Mana Boost", 1, 10, 1.5f, 30f);    // +50% for 30 sec
            AddPotion("mana_boost_2", "Light Mana Boost", 2, 25, 2.0f, 45f);    // +100% for 45 sec
            AddPotion("mana_boost_3", "Standard Mana Boost", 3, 50, 2.5f, 60f); // +150% for 1 min
            AddPotion("mana_boost_4", "Greater Mana Boost", 4, 100, 3.0f, 90f); // +200% for 1.5 min
            AddPotion("mana_boost_5", "Supreme Mana Boost", 5, 200, 4.0f, 120f);// +300% for 2 min
        }

        private void AddHealthBoostPotions()
        {
            const EItemType IconType = EItemType.HealthPotion;
            const float PotionWeight = 0.3f;

            void AddPotion(string id, string name, int level, int cost, float boostMultiplier, float duration)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Health,
                    BoostMultiplier = boostMultiplier,
                    EffectDuration = duration
                });
            }

            // Health regeneration boost potions (tiers 1-5)
            AddPotion("health_boost_1", "Minor Health Boost", 1, 15, 1.5f, 30f);    // +50% for 30 sec
            AddPotion("health_boost_2", "Light Health Boost", 2, 35, 2.0f, 45f);    // +100% for 45 sec
            AddPotion("health_boost_3", "Standard Health Boost", 3, 70, 2.5f, 60f); // +150% for 1 min
            AddPotion("health_boost_4", "Greater Health Boost", 4, 140, 3.0f, 90f); // +200% for 1.5 min
            AddPotion("health_boost_5", "Supreme Health Boost", 5, 280, 4.0f, 120f);// +300% for 2 min
        }

        private void AddStaminaBoostPotions()
        {
            const EItemType IconType = EItemType.StaminaPotion;
            const float PotionWeight = 0.3f;

            void AddPotion(string id, string name, int level, int cost, float boostMultiplier, float duration)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Stamina,
                    BoostMultiplier = boostMultiplier,
                    EffectDuration = duration
                });
            }

            // Stamina regeneration boost potions (tiers 1-5)
            AddPotion("stamina_boost_1", "Minor Stamina Boost", 1, 12, 1.5f, 30f);    // +50% for 30 sec
            AddPotion("stamina_boost_2", "Light Stamina Boost", 2, 30, 2.0f, 45f);    // +100% for 45 sec
            AddPotion("stamina_boost_3", "Standard Stamina Boost", 3, 60, 2.5f, 60f); // +150% for 1 min
            AddPotion("stamina_boost_4", "Greater Stamina Boost", 4, 120, 3.0f, 90f); // +200% for 1.5 min
            AddPotion("stamina_boost_5", "Supreme Stamina Boost", 5, 240, 4.0f, 120f);// +300% for 2 min
        }

        private void AddManaIncreasePotions()
        {
            const EItemType IconType = EItemType.ManaPotion;
            const float PotionWeight = 0.3f;

            void AddPotion(string id, string name, int level, int cost, int manaIncrease, float duration)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Mana,
                    StatIncrease = manaIncrease,
                    EffectDuration = duration,
                });
            }

            // Max mana increase potions (tiers 1-5)
            AddPotion("max_mana_1", "Minor Wisdom Potion", 1, 25, 15, 180f);    // +15 MP for 3 min
            AddPotion("max_mana_2", "Light Wisdom Potion", 2, 50, 30, 240f);    // +30 MP for 4 min
            AddPotion("max_mana_3", "Standard Wisdom Potion", 3, 100, 50, 300f); // +50 MP for 5 min
            AddPotion("max_mana_4", "Greater Wisdom Potion", 4, 200, 80, 360f);  // +80 MP for 6 min
            AddPotion("max_mana_5", "Supreme Wisdom Potion", 5, 400, 120, 480f);// +120 MP for 8 min
        }

        private void AddStaminaIncreasePotions()
        {
            const EItemType IconType = EItemType.StaminaPotion;
            const float PotionWeight = 0.3f;

            void AddPotion(string id, string name, int level, int cost, int staminaIncrease, float duration)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Stamina,
                    StatIncrease = staminaIncrease,
                    EffectDuration = duration,
                });
            }

            // Max stamina increase potions (tiers 1-5)
            AddPotion("max_stamina_1", "Minor Vigor Potion", 1, 18, 25, 180f);   // +25 SP for 3 min
            AddPotion("max_stamina_2", "Light Vigor Potion", 2, 40, 50, 240f);    // +50 SP for 4 min
            AddPotion("max_stamina_3", "Standard Vigor Potion", 3, 80, 80, 300f); // +80 SP for 5 min
            AddPotion("max_stamina_4", "Greater Vigor Potion", 4, 160, 120, 360f);// +120 SP for 6 min
            AddPotion("max_stamina_5", "Supreme Vigor Potion", 5, 320, 180, 480f);// +180 SP for 8 min
        }

        private void AddHealthIncreasePotions()
        {
            const EItemType IconType = EItemType.HealthPotion;
            const float PotionWeight = 0.3f; 

            void AddPotion(string id, string name, int level, int cost, int healthIncrease, float duration)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Health,
                    StatIncrease = healthIncrease,  
                    EffectDuration = duration,
                });
            }

            // Max health increase potions (tiers 1-5)
            AddPotion("max_health_1", "Minor Fortitude Potion", 1, 20, 20, 180f);   // +20 HP for 3 min
            AddPotion("max_health_2", "Light Fortitude Potion", 2, 45, 40, 240f);    // +40 HP for 4 min
            AddPotion("max_health_3", "Standard Fortitude Potion", 3, 90, 70, 300f); // +70 HP for 5 min
            AddPotion("max_health_4", "Greater Fortitude Potion", 4, 180, 110, 360f);// +110 HP for 6 min
            AddPotion("max_health_5", "Supreme Fortitude Potion", 5, 360, 160, 480f);// +160 HP for 8 min
        }

        private void AddHealthRecoveryPotions()
        {
            const EItemType IconType = EItemType.HealthPotion;
            const float PotionWeight = 0.3f;

            void AddPotion(string id, string name, int level, int cost, int healAmount)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Health,
                    StatIncrease = healAmount,
                    IsInstantEffect = true  
                });
            }

            // Health recovery potions (tiers 1-5)
            AddPotion("health_potion_1", "Minor Healing Potion", 1, 10, 25);   // +25 HP
            AddPotion("health_potion_2", "Light Healing Potion", 2, 25, 50);   // +50 HP
            AddPotion("health_potion_3", "Standard Healing Potion", 3, 50, 100);// +100 HP
            AddPotion("health_potion_4", "Greater Healing Potion", 4, 100, 200);// +200 HP
            AddPotion("health_potion_5", "Supreme Healing Potion", 5, 200, 400);// +400 HP
        }

        private void AddManaRecoveryPotions()
        {
            const EItemType IconType = EItemType.ManaPotion;
            const float PotionWeight = 0.3f; 

            void AddPotion(string id, string name, int level, int cost, int manaAmount)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Mana,
                    StatIncrease = manaAmount,
                    IsInstantEffect = true
                });
            }

            // Mana recovery potions (tiers 1-5)
            AddPotion("mana_potion_1", "Minor Mana Potion", 1, 15, 20);   // +20 MP
            AddPotion("mana_potion_2", "Light Mana Potion", 2, 35, 40);   // +40 MP
            AddPotion("mana_potion_3", "Standard Mana Potion", 3, 70, 80); // +80 MP
            AddPotion("mana_potion_4", "Greater Mana Potion", 4, 140, 160);// +160 MP
            AddPotion("mana_potion_5", "Supreme Mana Potion", 5, 280, 320);// +320 MP
        }

        private void AddStaminaRecoveryPotions()
        {
            const EItemType IconType = EItemType.StaminaPotion;
            const float PotionWeight = 0.3f; 

            void AddPotion(string id, string name, int level, int cost, int staminaAmount)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Stamina,
                    StatIncrease = staminaAmount,
                    IsInstantEffect = true
                });
            }

            // Stamina recovery potions (tiers 1-5)
            AddPotion("stamina_potion_1", "Minor Energy Potion", 1, 8, 30);   // +30 SP
            AddPotion("stamina_potion_2", "Light Energy Potion", 2, 20, 60);   // +60 SP
            AddPotion("stamina_potion_3", "Standard Energy Potion", 3, 40, 120);// +120 SP
            AddPotion("stamina_potion_4", "Greater Energy Potion", 4, 80, 240);// +240 SP
            AddPotion("stamina_potion_5", "Supreme Energy Potion", 5, 160, 480);// +480 SP
        }

        private void AddPoisons()
        {
            const EItemType IconType = EItemType.Poison;
            const float PotionWeight = 0.3f;

            void AddPoison(string id, string name, int level, int cost, int damagePerTick, float duration, int tickCount)
            {
                AddConfig(new PotionConfig
                {
                    ItemConfigKey = id,
                    ItemDefaultName = name,
                    Weight = PotionWeight,
                    BasicСost = cost,
                    ItemType = IconType,
                    PotionLevel = level,
                    AffectedStat = EPlayerStat.Health,
                    StatIncrease = -damagePerTick, 
                    EffectDuration = duration,
                    TickInterval = duration / tickCount,
                    IsHarmfulEffect = true,
                    IsInstantEffect = false
                });
            }

            // Poison potions (tiers 1-5)
            AddPoison("weak_poison", "Weak Poison", 1, 15, 5, 10f, 5);     // 5 damage/sec (25 total) for 10 sec
            AddPoison("mild_poison", "Mild Poison", 2, 30, 8, 12f, 6);    // 8 damage/sec (48 total) for 12 sec
            AddPoison("standard_poison", "Standard Poison", 3, 60, 12, 15f, 5); // 12 damage/3 sec (60 total) for 15 sec
            AddPoison("strong_poison", "Strong Poison", 4, 120, 20, 12f, 4);   // 20 damage/3 sec (80 total) for 12 sec
            AddPoison("deadly_poison", "Deadly Poison", 5, 240, 30, 10f, 5);   // 30 damage/2 sec (150 total) for 10 sec
        }

        private void AddConfig(ItemConfig config)
        {
            _configs[config.ItemConfigKey] = config;
        }
    }
}

