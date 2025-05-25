using System;
using UnityEngine;

namespace RPGMechanics.Characters.Player
{
    public class PlayerCharacter : Character
    {
        [field: SerializeField] public PlayerInventory PlayerInventory { get; private set; }
        public override Inventory Inventory => PlayerInventory;

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