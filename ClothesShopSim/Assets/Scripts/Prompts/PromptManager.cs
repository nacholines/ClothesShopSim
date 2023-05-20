using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptManager : MonoBehaviour
{
    private static PromptManager _instance;
    private PromptBase _currentPrompt;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
    }
    public static PromptManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PromptManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<PromptManager>();
                    singletonObject.name = "PromptManager";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    public PromptBase ShowPrompt(PromptBase promptBase)
    {
        if (_currentPrompt) Destroy(_currentPrompt.gameObject);
        _currentPrompt = Instantiate(promptBase.gameObject, _canvas.transform).GetComponent<PromptBase>();
        return _currentPrompt;
    }
}
