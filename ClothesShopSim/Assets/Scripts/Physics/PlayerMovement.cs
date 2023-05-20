using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Keys")]
    [Space(1)]
    public KeyCode[] Controls;
    
    [Header("Values")]
    [Space(1)]
    [SerializeField] float movementSpeed = 5f;

    private Vector3 _movement;



    void Update()
    {
        if(WindowManager.Instance.IsAnyWindowOpen) return;
        
        _movement = Vector3.zero;

        if (Input.GetKey(Controls[0]))
        {
            _movement += Vector3.up;
        }

        if (Input.GetKey(Controls[1]))
        {
            _movement += Vector3.down;
        }

        if (Input.GetKey(Controls[2]))
        {
            _movement += Vector3.left;
        }

        if (Input.GetKey(Controls[3]))
        {
            _movement += Vector3.right;
        }

        transform.position += _movement * Time.deltaTime * movementSpeed;
    }
}
