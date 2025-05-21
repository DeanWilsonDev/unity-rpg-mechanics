using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
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

    private EventTrigger eventTrigger;

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

        eventTrigger = GetComponent<EventTrigger>();
        if (!eventTrigger)
        {
            eventTrigger = gameObject.AddComponent<EventTrigger>();
        }
        
        eventTrigger.triggers.Clear();

        var entryEnter = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerEnter
        };
        
        entryEnter.callback.AddListener((data) => {SelectItem((PointerEventData)data);});

        var entryExit = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerExit
        };
        
        entryExit.callback.AddListener((data) => {DeselectItem((PointerEventData)data);});
        
        eventTrigger.triggers.Add(entryEnter);
        eventTrigger.triggers.Add(entryExit);
    }


    public void SelectItem(PointerEventData data)
    {
        itemPrefab.SetActive(true);
        SetText(titleField, itemName);
        SetText(descriptionField, description);
        SetText(weightField, weight);
        SetText(valueField, value);
    }
    

    public void DeselectItem(PointerEventData data)
    { itemPrefab.SetActive(false);
    }


    private static void SetText(TextMeshProUGUI field, string text)
    {
        if (!field) return;
        field.text= text;
    }
    
}
