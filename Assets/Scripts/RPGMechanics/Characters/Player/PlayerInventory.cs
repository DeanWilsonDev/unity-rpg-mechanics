using RPGMechanics.Items;

namespace RPGMechanics.Characters.Player
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