using System;
using UnityEngine;

namespace RPGMechanics.Characters.Enemies
{
    public class Enemy : Character
    {
        [field: SerializeField] public EnemyInventory EnemyInventory { get; private set; }
        public override Inventory Inventory => EnemyInventory;

        protected override void Start()
        {
            base.Start();
        }

        public override void KillCharacter()
        {
            throw new NotImplementedException();
        }

        public override void OnDeath()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}