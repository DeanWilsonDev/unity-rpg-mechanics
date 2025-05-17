using System.Collections.Generic;
using Items;

namespace Characters 
{
    public abstract class Inventory
    {
        protected List<Item> Items = new List<Item>();

        /// <summary>
        /// Helper method to get all items in the inventory.
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems()
        {
            return Items;
        }

        /// <summary>
        /// Helper method to add an item to the inventory.
        /// </summary>
        /// <param name="item"></param>
        public void AddItemToInventory(Item item)
        {
            Items.Add(item);
        }
        
        /// <summary>
        /// Helper method to remove an item from the inventory.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemFromInventory(Item item)
        {
            Items.Remove(item);
        }
        
    }
}