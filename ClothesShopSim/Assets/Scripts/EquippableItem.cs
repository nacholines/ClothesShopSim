using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippableItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private ActionButton actionButton;

    public Item Item => _item;

    private Item _item;

    public void SetItem(Item item, ItemInteraction action)
    {
        image.sprite = item.Sprite;
        itemName.text = item.name;
        actionButton.SetActionButton(action.type, action.callback, item);
    }
}
