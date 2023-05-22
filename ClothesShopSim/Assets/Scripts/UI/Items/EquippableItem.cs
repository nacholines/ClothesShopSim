using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquippableItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private ActionButton actionButton;

    public Item Item => _item;

    private Item _item;

    public void SetItem(Item item, ItemInteraction action)
    {
        image.sprite = item.Sprite;
        float aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
        image.SetNativeSize();
        AspectRatioFitter fitter = image.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;
        actionButton.SetActionButton(action.type, action.callback, item);
    }
}
