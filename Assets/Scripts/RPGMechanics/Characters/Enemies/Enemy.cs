using System;
using UnityEngine;

namespace RPGMechanics.Characters.Enemies
{
    public class Enemy : Character
    {
        [SerializeField] private EnemyInventory inventory;

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