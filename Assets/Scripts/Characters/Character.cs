using Characters.Statistics;
using UnityEngine;

namespace Characters
{
    public abstract class Character : MonoBehaviour, IDamagable
    {
        [SerializeField] protected internal CharacterStatistics statistics;
        [SerializeField] protected internal string characterName;
        [SerializeField] protected internal CharacterType characterType;
        [SerializeField] protected internal Inventory inventory;

        public CharacterStatistics Statistics => statistics;
        public string CharacterName => characterName;
        public CharacterType CharacterType => characterType;
        public Inventory Inventory => inventory;

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
        public abstract void OnDeath();
        public abstract void Move();
    }
}