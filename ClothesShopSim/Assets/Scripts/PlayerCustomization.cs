using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [SerializeField] private SpriteRenderer faceSprite;
    [SerializeField] private SpriteRenderer hairSprite;
    [SerializeField] private SpriteRenderer shirtSprite;
    [SerializeField] private SpriteRenderer pantsSprite;

    public void WearItem(Item item)
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
