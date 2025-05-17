using Characters.Statistics;

namespace Items
{
    public abstract class Consumable : Item, IConsumable
    {
        public abstract event IConsumable.ConsumableEffect Consume;

        protected Consumable(string name, string description, int price, int weight, int level, ItemRarity rarity,
            int type, int slot) : base(name, description, price, weight, level, rarity, type, slot)
        {
        }

        public abstract void OnConsume(CharacterStatistics statistics);
    }
}