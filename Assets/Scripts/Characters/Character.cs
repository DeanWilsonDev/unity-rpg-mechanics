using Characters.Statistics;
using UnityEngine;

namespace Characters
{
    public abstract class Character : MonoBehaviour, IDamagable
    {
        [SerializeField] public CharacterStatistics statistics;
        [SerializeField] public string characterName;
        [SerializeField] public CharacterType characterType;

        protected virtual void Start()
        {
            statistics = StatisticGenerator.GetStatisticsForLevel(1, characterType);
        }

        public float TakeDamage(int damage)
        {
            var finalDamage = Mathf.Max(damage - statistics.Constitution, 0);
            statistics.CurrentHealth -= finalDamage;
            statistics.CurrentHealth = Mathf.Max(statistics.CurrentHealth, 0);
            if (IsDead())
            {
                KillCharacter();
            }

            return statistics.CurrentHealth;
        }

        public bool IsDead()
        {
            return statistics.CurrentHealth <= 0;
        }

        public abstract void KillCharacter();
    }
}