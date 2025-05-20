using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI: MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private string weight;
    [SerializeField] private string value;

    [SerializeField] private TextMeshProUGUI titleField;
    [SerializeField] private TextMeshProUGUI descriptionField;
    [SerializeField] private TextMeshProUGUI weightField;
    [SerializeField] private TextMeshProUGUI valueField;

    public void OnValidate()
    {
        var button = GetComponentInChildren<Button>();
        if (button)
        {
            var tmp = button.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp)
            {
                tmp.text = itemName;
            }
        }
    }


    public void SelectItem()
    {
        itemPrefab.SetActive(true);
        SetText(titleField, itemName);
        SetText(descriptionField, description);
        SetText(weightField, weight);
        SetText(valueField, value);
    }
    

    public void DeselectItem()
    {
        itemPrefab.SetActive(false);
    }


    private static void SetText(TextMeshProUGUI field, string text)
    {
        if (!field) return;
        field.text= text;
    }
    
}
