using UnityEngine;

namespace ItemSystem
{
    // Class for storing recipe data
    public class CookedMeatRecipe
    {
        public string InputMeatId { get; }
        public string OutputId { get; }
        public string Name { get; }
        public int Portions { get; }  // Number of portions
        public float WeightPerPortion { get; } // Portion weight in kg
        public int BaseCostPerPortion { get; } // Base cost without markup

        public CookedMeatRecipe(string meatId, string meatName)
        {
            InputMeatId = meatId;
            OutputId = $"cooked_{meatId}";
            Name = $"Fried {meatName}";

            // Calculate portion count
            var meatData = GetMeatData(meatId);
            Portions = Mathf.CeilToInt(meatData.Weight * 1000 / 250); // Convert kg to grams

            // Fixed portion weight
            WeightPerPortion = 0.25f; // 250 grams

            // Portion cost (meat + salt)
            float saltPerPortion = 0.02f; // 20g salt per portion
            int saltCost = Mathf.CeilToInt(2 * (saltPerPortion / 0.2f)); // Salt: 2 coins per 200g
            BaseCostPerPortion = Mathf.CeilToInt((meatData.BaseCost / Portions) + saltCost);
        }

        private (float Weight, int BaseCost) GetMeatData(string meatId)
        {
            // Data from AddRawMeats method
            return meatId switch
            {
                "chicken" => (0.8f, 8),
                "goat_meat" => (0.7f, 7),
                "pork" => (0.9f, 7),
                "rabbit" => (0.6f, 10),
                "lamb" => (0.8f, 12),
                "duck" => (0.7f, 14),
                "beef" => (1.0f, 18),
                "horse_meat" => (0.9f, 20),
                "venison" => (0.8f, 22),
                "goose" => (0.9f, 16),
                _ => (0f, 0)
            };
        }
    }
}


/*
Explanations for calculating the soup cost:
Basic formula: Cost = sum of cost of all ingredients + 30% markup + 2 coins for complexity

Chicken Noodle Soup
Ingredients:
1. Water - 500ml
2. Chicken breast - 200g (chicken)
3. Noodles - 100g (flour_wheat)
4. Carrot - 50g (carrot)
5. Onion - 50g (onion)
6. Salt - 10g (salt)
Cost: ~12 coins

Creamy Mushroom Soup
Ingredients:
1. Water - 500ml
2. Mushrooms - 150g (mushroom)
3. Potatoes - 100g (potato)
4. Cream - 50ml (milk)
5. Onion - 50g (onion)
6. Salt - 10g (salt)
7. Dill - 5g (greens)
Cost: ~10 coins

Borscht
Ingredients:
1. Water - 500ml
2. Beef - 150g (beef)
3. Beetroot - 100g (beet)
4. Cabbage - 100g (cabbage)
5. Potatoes - 50g (potato)
6. Carrot - 50g (carrot)
7. Onion - 50g (onion)
8. Tomato - 30g (tomato)
9. Salt - 10g (salt)
10. Sour cream - 30g (sour_cream)
Cost: ~15 coins

Pea Soup with Smoked Meat
Ingredients:
1. Water - 500ml
2. Peas - 100g (peas)
3. Smoked pork - 100g (smoked_pork)
4. Potatoes - 50g (potato)
5. Carrot - 50g (carrot)
6. Onion - 50g (onion)
7. Salt - 10g (salt)
Cost: ~14 coins

Seasonal Vegetable Soup
Ingredients:
1. Water - 500ml
2. Potatoes - 100g (potato)
3. Carrot - 50g (carrot)
4. Cabbage - 50g (cabbage)
5. Onion - 50g (onion)
6. Herbs - 10g (greens)
7. Salt - 10g (salt)
Cost: ~8 coins

Meat Solyanka
Ingredients:
1. Water - 500ml
2. Beef - 100g (beef)
3. Ham - 50g (ham)
4. Sausage - 50g (sausage)
5. Pickles - 50g (pickle)
6. Capers - 20g (capers)
7. Lemon - 20g (lemon)
8. Olives - 20g (olives)
9. Salt - 10g (salt)
10. Sour cream - 30g (sour_cream)
Cost: ~18 coins

Creamy Pumpkin Soup
Ingredients:
1. Water - 300ml
2. Pumpkin - 200g (pumpkin)
3. Cream - 100ml (milk)
4. Ginger - 10g (ginger)
5. Garlic - 5g (garlic)
6. Salt - 10g (salt)
Cost: ~12 coins

Fisherman's Soup (Ukha)
Ingredients:
1. Water - 500ml
2. River fish - 200g (river_fish)
3. Potatoes - 100g (potato)
4. Onion - 50g (onion)
5. Carrot - 30g (carrot)
6. Bay leaf - 2g (bay_leaf)
7. Peppercorns - 3g (pepper)
8. Salt - 10g (salt)
Cost: ~16 coins
*/