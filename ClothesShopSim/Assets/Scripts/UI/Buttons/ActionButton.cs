using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI actionName;
    [SerializeField] private Button button;


    public void SetActionButton(string description, Action<Item> callback, Item item)
    {
        if(actionName) actionName.text = description;
        button.onClick.AddListener(()=> callback?.Invoke(item));
    }
}
