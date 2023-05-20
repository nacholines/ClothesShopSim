using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    private static WindowManager _instance;

    private Canvas _canvas;
    private WindowBase _currentWindow;

    public bool IsAnyWindowOpen => _currentWindow != null;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
    }
    public static WindowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WindowManager>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<WindowManager>();
                    singletonObject.name = "WindowManager";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }


    public WindowBase OpenWindow(WindowBase windowBase)
    {
        if (_currentWindow) Destroy(_currentWindow.gameObject);
        _currentWindow = Instantiate(windowBase.gameObject, _canvas.transform).GetComponent<WindowBase>();
        return _currentWindow;
    }
}
