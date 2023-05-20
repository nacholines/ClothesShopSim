using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public float Price;
    public string Description;
    public Type type;

    public enum Type
    {
        HAIR,
        FACE,
        SHIRT,
        PANTS
    }
}




