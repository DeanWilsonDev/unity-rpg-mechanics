using System;

using RPGMechanics.Characters.Statistics;

using Unity.VisualScripting;

using UnityEngine;

namespace RPGMechanics.Characters
{
    public class Health : MonoBehaviour, IDamagable
    {
        public delegate float DamageEffect(float damage);

        public DamageEffect TakeDamageEffect { get; set; }

        public delegate void KillEvent();

        public KillEvent KillEffect { get; set; }

        public float CurrentHealth { get => statistics.CurrentHealth; private set => statistics.CurrentHealth = value; }
        public float MaxHealth { get => statistics.MaxHealth; private set => statistics.MaxHealth = value; }
        
        private float characterDefenseRating;
        private CharacterStatistics statistics;

        public void Initialize(CharacterStatistics stats)
        {
            this.statistics = stats;
            this.characterDefenseRating = stats.Constitution;
        }

        public float OnTakeDamage(float damage)
        {
            if (TakeDamageEffect != null)
            {
                return TakeDamageEffect.Invoke(damage);
            }

            return 0;
        }

        public virtual float TakeDamage(float damage)
        {
            var finalDamage = Mathf.Max(damage - characterDefenseRating, 0);
            CurrentHealth -= finalDamage;
            CurrentHealth = Mathf.Max(CurrentHealth, 0);
            if (IsDead())
            {
                KillEffect?.Invoke();
                Destroy(gameObject); // Pooling?
                
            } // TODO: Find a way to kill the player by changing their state in the state machine

            return CurrentHealth;
        }

        public bool IsDead()
        {
            return CurrentHealth <= 0;
        }
    }
}