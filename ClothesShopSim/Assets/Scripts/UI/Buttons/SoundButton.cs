using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private AudioSource _audioSource;
    private Button _button;

    [SerializeField] Sound sound;


    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        _audioSource.clip = sound.Clip;
        _audioSource.volume = sound.Volume;
        _audioSource.Play();
    }


}
