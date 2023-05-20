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

    public Sprite Face
    {
        get {return face.sprite;}
        set{ face.sprite = value;} 
    }
    public Sprite Hair
    {
        get { return hair.sprite; }
        set { hair.sprite = value;
            hair.gameObject.SetActive(hair.sprite != null);}
    }

    public Sprite Shirt
    {
        get { return shirt.sprite; }
        set { shirt.sprite = value; }
    }


    public Sprite Pants
    {
        get { return pants.sprite; }
        set { pants.sprite = value; }
    }
    public void EquipItem(Item item)
    {
        switch (item.type)
        {
            case Item.Type.HAIR:
                hair.sprite = item.Sprite;
                hair.gameObject.SetActive(hair.sprite != null);
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
