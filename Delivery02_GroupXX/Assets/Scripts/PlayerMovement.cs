using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving => _isMoving;

    [SerializeField]
    private float _speed = 5;


    private bool _isMoving;
    PlayerInput _input;
    Rigidbody2D _rigidbody;
    private float _horizontalDir;
    private float _verticalDir;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = _horizontalDir * _speed;
        velocity.y = _verticalDir * _speed;
        _rigidbody.velocity = velocity;
    }

    void Update()
    {

    }

    void OnMovement(InputValue value)
    {
        var inputVal = value.Get<Vector2>();
        _horizontalDir = inputVal.x;
        _verticalDir = inputVal.y;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}

