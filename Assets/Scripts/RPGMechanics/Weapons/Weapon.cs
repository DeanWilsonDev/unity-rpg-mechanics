using UnityEngine;

namespace RPGMechanics.Weapons
{
    public abstract class Weapon
    {
        [field: SerializeField] public float Damage { get; set; }
        [field: SerializeField] public float Range { get; set; }
        [field: SerializeField] public float Radius { get; set; }
    }
}