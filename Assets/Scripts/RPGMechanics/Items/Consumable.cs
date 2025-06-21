using RPGMechanics.Characters.Statistics;

namespace RPGMechanics.Items
{
    public abstract class Consumable : Item, IConsumable
    {
        public abstract event IConsumable.ConsumableEffect Consume;
        public abstract void OnConsume(CharacterStatistics statistics);
    }
}