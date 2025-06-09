using RPGMechanics.Characters.Statistics;

using UnityEngine;

namespace RPGMechanics.Characters
{
    public class Health: MonoBehaviour, IDamagable
    {
       [field: SerializeField] public float CurrentHealth { get; private set; } 
       [field: SerializeField] public float MaxHealth { get; private set; }
       private float characterDefenseRating;

       public void Initialize(CharacterStatistics stats)
       {
           this.CurrentHealth = stats.CurrentHealth;
           this.MaxHealth = stats.Vitality;
           this.characterDefenseRating = stats.Constitution;
       }
        
       public float TakeDamage(float damage)
       {
           var finalDamage = Mathf.Max(damage - characterDefenseRating, 0);
           CurrentHealth -= finalDamage;
           CurrentHealth = Mathf.Max(CurrentHealth, 0);
           if (IsDead()){} // TODO: Find a way to kill the player by changing their state in the state machine
           return CurrentHealth;
       }

       public bool IsDead()
       {
            return CurrentHealth <= 0;
       }
    }
}