using UnityEngine;

namespace RPGMechanics.Characters.Enemies
{
    public class EnemyInventory : Inventory
    {
        [SerializeField] private int maxItems;

        public int MaxItems
        {
            get => maxItems;
            set => maxItems = value;
        }
    }
}