using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "ScriptableObjects/Sound")]
public class Sound : ScriptableObject
{
    public AudioClip Clip;
    public float Volume;
}
