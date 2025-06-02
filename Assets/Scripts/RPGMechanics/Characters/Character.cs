using System;

using RPGMechanics.Characters.Statistics;
using RPGMechanics.StateMachines;

using UnityEngine;

using StateMachine = RPGMechanics.StateMachines.StateMachine;

namespace RPGMechanics.Characters
{
    public abstract class Character : MonoBehaviour, IDamagable
    {
        public event Action DeathEvent;
        [SerializeField] protected internal CharacterStatistics statistics;
        [SerializeField] protected internal string characterName;
        [SerializeField] protected internal CharacterType characterType;
        [SerializeField] protected internal StateMachine stateMachine;
        protected abstract StateMachine StateMachine { get; }
        public abstract State DeathState { get; set; }
        public abstract State IdleState { get; set; }
        public abstract State RunningState { get; set; }
        

        public CharacterStatistics Statistics => statistics;
        public string CharacterName => characterName;
        public CharacterType CharacterType => characterType;

        public abstract Inventory Inventory { get; }

        protected virtual void Start()
        {
            statistics = StatisticGenerator.GetStatisticsForLevel(1, characterType);
        }

        public float TakeDamage(int damage)
        {
            var finalDamage = Mathf.Max(damage - statistics.Constitution, 0);
            statistics.CurrentHealth -= finalDamage;
            statistics.CurrentHealth = Mathf.Max(statistics.CurrentHealth, 0);
            if (IsDead()) StateMachine.SwitchState(DeathState);
            return statistics.CurrentHealth;
        }

        public bool IsDead()
        {
            return statistics.CurrentHealth <= 0;
        }
    }
}