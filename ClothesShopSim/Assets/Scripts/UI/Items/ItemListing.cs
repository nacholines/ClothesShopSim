using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemListing : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private ActionButton actionButton;

    public Item Item => _item;

    private Item _item;

    public void SetItem(Item item, ItemInteraction action)
    {
        _item = item;
        image.sprite = item.Sprite;
        float aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
        image.SetNativeSize();
        AspectRatioFitter fitter = image.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;
        description.text = item.Description;
        itemName.text = item.Name;
        price.text = item.Price.ToString();
        actionButton.SetActionButton(action.type, action.callback, item);
    }


}
