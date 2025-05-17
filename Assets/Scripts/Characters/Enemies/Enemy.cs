using UnityEngine;

namespace Characters.Enemies
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
            throw new System.NotImplementedException();
        }
    }
}