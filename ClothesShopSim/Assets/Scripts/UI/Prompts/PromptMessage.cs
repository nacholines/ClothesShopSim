using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptMessage : PromptBase
{
    [SerializeField] private TextMeshProUGUI message;

    private void Awake()
    {
        message.gameObject.SetActive(false);
    }
    public void SetMessage(string textMessage)
    {
        message.text = textMessage;
    }

    public override void ShowPrompt(Action callback = null)
    {
        base.ShowPrompt(()=>
        {
            message.gameObject.SetActive(true);
            callback?.Invoke();
        });
    }

    public override void HidePrompt()
    {
        base.HidePrompt();
        message.gameObject.SetActive(false);
    }

}
