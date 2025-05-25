using Characters.Statistics;

namespace RPGMechanics.Items
{
    public abstract class Consumable : Item, IConsumable
    {
        protected Consumable(string name, string description, int price, int weight, int level, ItemRarity rarity,
            int type, int slot) : base(name, description, price, weight, level, rarity, type, slot)
        {
        }

        public abstract event IConsumable.ConsumableEffect Consume;

        public abstract void OnConsume(CharacterStatistics statistics);
    }
}