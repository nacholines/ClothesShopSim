using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour, ICustomizable
{
    [Header("Sprites")]
    [Space(1)]
    [SerializeField] private SpriteRenderer faceSprite;
    [SerializeField] private SpriteRenderer hairSprite;
    [SerializeField] private SpriteRenderer shirtSprite;
    [SerializeField] private SpriteRenderer pantsSprite;

    public Sprite Face => faceSprite.sprite;
    public Sprite Hair => hairSprite.sprite;
    public Sprite Shirt => shirtSprite.sprite;
    public Sprite Pants => pantsSprite.sprite;
    public void EquipItem(Item item)
    {
        switch (item.type)
        {
            case Item.Type.HAIR:
                hairSprite.sprite = item.Sprite;
            break;

            case Item.Type.FACE:
                faceSprite.sprite = item.Sprite;
            break;

            case Item.Type.SHIRT:
                shirtSprite.sprite = item.Sprite;
            break;

            case Item.Type.PANTS:
                pantsSprite.sprite = item.Sprite;
            break;
        }
    }
}
