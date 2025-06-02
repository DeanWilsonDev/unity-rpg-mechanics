using System;

using RPGMechanics.StateMachines;
using RPGMechanics.StateMachines.Enemy;

using UnityEngine;

using StateMachine = RPGMechanics.StateMachines.StateMachine;

namespace RPGMechanics.Characters.Enemies
{
    public class Enemy : Character
    {
        [field: SerializeField] public EnemyInventory EnemyInventory { get; private set; }
        [field: SerializeField] public EnemyStateMachine EnemyStateMachine { get; set; }
        protected override StateMachine StateMachine => EnemyStateMachine;
        public override State DeathState { get; set; }
        public override State IdleState { get; set; }
        public override State RunningState { get; set; }
        public override Inventory Inventory => EnemyInventory;

        protected override void Start()
        {
            base.Start();
        }

        public void OnDeath()
        {
            throw new NotImplementedException();
        }
    }
}