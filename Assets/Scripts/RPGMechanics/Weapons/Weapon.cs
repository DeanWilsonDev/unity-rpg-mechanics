using UnityEngine;

namespace RPGMechanics.Weapons
{
    public class Weapon: MonoBehaviour
    {
        [field: SerializeField] public float Damage { get; set; }
        [field: SerializeField] public float Range { get; set; }
        [field: SerializeField] public float Radius { get; set; }
    }
}