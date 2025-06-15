using RPGMechanics.Characters;
using RPGMechanics.Items;

namespace RPGMechanics.Inventory
{
    public class PlayerInventory : Inventory
    {
        public void UseItem(Consumable consumableItem, Character character)
        {
            consumableItem.OnConsume(character.Statistics);
            RemoveItemFromInventory(consumableItem);
        }
    }
}