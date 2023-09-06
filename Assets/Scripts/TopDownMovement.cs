using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementDirection = Vector2.zero;

    public float moveSpeed = 3f;

    private void Awake()
    {
        _controller = this.GetComponent<TopDownCharacterController>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            GameManager.Instance.animationController.SetMoveState(true);
        }
        else
        {
            GameManager.Instance.animationController.SetMoveState(false);
        }


        if(direction.x < 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(direction.x > 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        _rigidbody.velocity = direction * moveSpeed;
    }
}
