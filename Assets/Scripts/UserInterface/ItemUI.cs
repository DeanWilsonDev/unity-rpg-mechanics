using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI: MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private string weight;
    [SerializeField] private string value;

    public void OnValidate()
    {
        var button = GetComponentInChildren<Button>();
        if (button)
        {
            var tmp = button.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp)
            {
                tmp.text = name;
            }

            button.onClick.AddListener(SelectItem);

        }
    }


    void SelectItem()
    {
        itemPrefab.SetActive(!itemPrefab.activeSelf);
    }
}
