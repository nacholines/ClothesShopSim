using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PromptMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;

    public void SetMessage(string textMessage)
    {
        message.text = textMessage;
    }

}
