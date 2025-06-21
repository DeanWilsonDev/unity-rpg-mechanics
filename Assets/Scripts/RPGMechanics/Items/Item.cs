using UnityEngine;

namespace RPGMechanics.Items
{
    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Artifact,
        MainQuestItem,
        QuestItem,
        Unknown
    }

    [System.Serializable]
    public class Item : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public string Description { get; set; }
        [field: SerializeField] public int Value { get; set; }
        [field: SerializeField] public int Weight { get; set; }
        [field: SerializeField] public int Level { get; set; }
        [field: SerializeField] public ItemRarity Rarity { get; set; }
        [field: SerializeField] public int Type { get; set; }
        [field: SerializeField] public int Slot { get; set; }
        [field: SerializeField] public string[] Tags { get; set; }
    }
}