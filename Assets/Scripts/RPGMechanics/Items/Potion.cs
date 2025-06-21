using RPGMechanics.Characters.Statistics;

namespace RPGMechanics.Items
{
    public class Potion: Consumable
    {
        public override event IConsumable.ConsumableEffect Consume;
        
        public override void OnConsume(CharacterStatistics statistics)
        {
            throw new System.NotImplementedException();
        }
    }
}