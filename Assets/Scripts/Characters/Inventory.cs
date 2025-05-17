using System.Collections.Generic;
using Characters;
using Items;

namespace Characters 
{
    public class Inventory
    {
        public List<Item> Items = new List<Item>();

        public void UseItem(Consumable consumableItem, Character character)
        {
            consumableItem.OnConsume(character.statistics);
            Items.Remove(consumableItem);
        }
    }
}