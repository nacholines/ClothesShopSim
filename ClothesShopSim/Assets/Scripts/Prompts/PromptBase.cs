using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptBase : MonoBehaviour
{
    public virtual void ShowPrompt(Action callback = null)
    {
        transform.localScale = Vector2.up;
        LeanTween.scaleX(gameObject, 1, 0.25f).setEaseLinear().setOnComplete(()=> callback?.Invoke());
    }

    public virtual void HidePrompt()
    {
        LeanTween.scaleX(gameObject, 0, 0.15f).setEaseLinear().setDestroyOnComplete(true);
    }
}
