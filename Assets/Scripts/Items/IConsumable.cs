using Characters.Statistics;

namespace Items
{
    public interface IConsumable
    {
       public delegate void ConsumableEffect(int amount); 
       public event ConsumableEffect Consume;
       public abstract void OnConsume(CharacterStatistics statistics);
    }
}