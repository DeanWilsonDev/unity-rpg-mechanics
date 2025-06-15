using UnityEngine;

namespace RPGMechanics.Inventory
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