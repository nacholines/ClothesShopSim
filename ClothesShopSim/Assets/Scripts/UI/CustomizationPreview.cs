using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationPreview : MonoBehaviour, ICustomizable
{
    [SerializeField] private Image face;
    [SerializeField] private Image hair;
    [SerializeField] private Image shirt;
    [SerializeField] private Image pants;


    public void EquipItem(Item item)
    {
        switch (item.type)
        {
            case Item.Type.HAIR:
                hair.sprite = item.Sprite;
                break;

            case Item.Type.FACE:
                face.sprite = item.Sprite;
                break;

            case Item.Type.SHIRT:
                shirt.sprite = item.Sprite;
                break;

            case Item.Type.PANTS:
                pants.sprite = item.Sprite;
                break;
        }
    }
}
