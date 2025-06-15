using System.Collections.Generic;
using RPGMechanics.Items;

using UnityEngine;

namespace RPGMechanics.Inventory
{
    public abstract class Inventory: MonoBehaviour
    {
        [field: SerializeField] protected List<Item> Items { get; set; } = new();

        /// <summary>
        ///     Helper method to get all items in the inventory.
        /// </summary>
        /// <returns></returns>
        public virtual List<Item> GetItems()
        {
            return Items;
        }

        /// <summary>
        ///     Helper method to add an item to the inventory.
        /// </summary>
        /// <param name="item"></param>
        public virtual void AddItemToInventory(Item item)
        {
            Items.Add(item);
        }

        /// <summary>
        ///     Helper method to remove an item from the inventory.
        /// </summary>
        /// <param name="item"></param>
        public virtual void RemoveItemFromInventory(Item item)
        {
            Items.Remove(item);
        }
    }
}