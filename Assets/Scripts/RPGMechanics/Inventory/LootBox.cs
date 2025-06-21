using RPGMechanics.Items;

using UnityEngine;

namespace RPGMechanics.Inventory
{
    public class LootBox : Inventory
    {
        // TODO: Should select items based on the type of enemy that drops the loot box

        [field: SerializeField] public Item[] ItemDatabase { get; set; }

        private void Start()
        {
            var itemData = Resources.Load<TextAsset>("Data/items");
            Debug.Log(itemData.ToString());
            ItemDatabase = JsonHelper.FromJsonArray<Item>(itemData.ToString());
        }
    }

    // TODO: This should live in it's own folder somewhere
    public static class JsonHelper
    {
        public static T[] FromJsonArray<T>(string json)
        {
            var jsonString = "{ \"array\": " + json + "}";
            var jsonWrapper = JsonUtility.FromJson<Wrapper<T>>(jsonString);
            return jsonWrapper.array;
        }


        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }


    
        
    
}
