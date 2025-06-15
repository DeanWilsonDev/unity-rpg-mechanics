using System;

using RPGMechanics.Inventory;

using UnityEngine;


namespace RPGMechanics.Characters.Enemies
{
    public class Enemy : Character
    {
        [field: SerializeField] public EnemyInventory EnemyInventory { get; private set; }
        public override Inventory.Inventory Inventory => EnemyInventory;

        public void OnDeath()
        {
            throw new NotImplementedException();
        }

        public override float TakeDamage(float damage)
        {
            var remainingHealth = base.TakeDamage(damage);
            var newColor = Color.Lerp(Color.red, Color.green, remainingHealth / 100);
            gameObject.GetComponent<Renderer>().material.color = newColor;
            return remainingHealth;
        }
    }
}