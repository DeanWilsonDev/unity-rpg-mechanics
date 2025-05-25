using RPGMechanics.Characters.Statistics;

namespace RPGMechanics.Items
{
    public interface IConsumable
    {
        public delegate void ConsumableEffect(int amount);

        public event ConsumableEffect Consume;
        public void OnConsume(CharacterStatistics statistics);
    }
}