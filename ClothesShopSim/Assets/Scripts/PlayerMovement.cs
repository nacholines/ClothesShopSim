using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public KeyCode[] Controls;
    private Vector3 _movement;
    public Rigidbody2D Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
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

        transform.position += _movement * Time.deltaTime * MovementSpeed;
    }
}
