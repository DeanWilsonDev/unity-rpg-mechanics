using RPGMechanics.Characters;
using UnityEngine;

namespace RPGMechanics.UserInterface
{
    public class ItemUIGenerator
    {
        [SerializeField] private Character character;

        private void OnEnable()
        {
            foreach (var item in character.Inventory.GetItems())
            {
                // TODO: Create ItemUI here and get Item model to create inventory screen
            }
        }
    }
}