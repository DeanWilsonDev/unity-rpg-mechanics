using UnityEngine;

namespace RPGMechanics.Items
{
    public class ItemsEffects
    {
        [field: SerializeField] public string Type { get; set; }
        [field: SerializeField] public int Amount { get; set; }
        [field: SerializeField] public float Chance { get; set; }
        [field: SerializeField] public float Duration { get; set; }
    }
}