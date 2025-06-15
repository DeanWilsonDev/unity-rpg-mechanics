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

    public class Item: MonoBehaviour
    {
        [SerializeField] private string description;
        [SerializeField] private int level;
        [SerializeField] private string name;
        [SerializeField] private int price;
        [SerializeField] private ItemRarity rarity;
        [SerializeField] private int slot;
        [SerializeField] private int type;
        [SerializeField] private int weight;


        public Item(
            string name,
            string description,
            int price,
            int weight,
            int level,
            ItemRarity rarity,
            int type,
            int slot)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.weight = weight;
            this.level = level;
            this.rarity = rarity;
            this.type = type;
            this.slot = slot;
        }


        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public ItemRarity Rarity
        {
            get => rarity;
            set => rarity = value;
        }

        public int Type
        {
            get => type;
            set => type = value;
        }

        public int Slot
        {
            get => slot;
            set => slot = value;
        }
    }
}