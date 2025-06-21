using UnityEngine;

namespace RPGMechanics.Items
{
    public class Weapon: Item
    {
        [field: SerializeField] public float Damage { get; set; }
        [field: SerializeField] public float Range { get; set; }
        [field: SerializeField] public float Speed { get; set; }
        
        [field: SerializeField] public float Radius { get; set; }
        [field: SerializeField] public Transform WeaponHoldSlot { get; set; }
        
    }
}