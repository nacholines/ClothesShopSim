using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowBase : MonoBehaviour
{
    [SerializeField] Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseWindow);
    }
    public void OpenWindow()
    {
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 0.25f).setEaseLinear();
    }

    public void CloseWindow()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.15f).setEaseLinear().setDestroyOnComplete(true);
    }

}
