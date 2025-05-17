using Items;

namespace Characters.Player
{
    public class PlayerInventory: Inventory
    {
        
        public void UseItem(Consumable consumableItem, Character character)
        {
            consumableItem.OnConsume(character.statistics);
            RemoveItemFromInventory(consumableItem);
        }
    }
}