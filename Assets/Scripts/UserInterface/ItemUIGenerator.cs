using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace UserInterface
{
    public class ItemUIGenerator
    {
        [SerializeField] private Character character;

        void OnEnable()
        {
            foreach (var item in character.Inventory.GetItems())
            {
                
                // TODO: Create ItemUI here and get Item model to create inventory screen
            }
        }
    }
}