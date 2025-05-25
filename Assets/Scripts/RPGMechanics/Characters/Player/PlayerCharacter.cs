using System;
using UnityEngine;

namespace RPGMechanics.Characters.Player
{
    public class PlayerCharacter : Character
    {
        [SerializeField] private PlayerInventory inventory;

        public PlayerInventory Inventory => inventory;

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