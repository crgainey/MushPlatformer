using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] float _jumpForce = 5f;

    [Tooltip("Set Ground Layer in editor")]
    [SerializeField] LayerMask _groundLayer;

    [Tooltip("Game object at feet of player")]
    [SerializeField] Transform _groundCheck;

    [SerializeField] int _maxJump = 1;
    int _currentJump = 0;

    Animator _animator;
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();   
    }

    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Jump") && _currentJump < _maxJump)
        {
            Jump();
        }

        IsGrounded();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        var movement = direction * _speed;
        transform.position += movement * Time.deltaTime;

        float velocity = Mathf.Abs(horizontalInput); // used for animation
        _animator.SetFloat("Walk Speed", (velocity * Time.deltaTime));

        //Used to face direction of movement
        if (!Mathf.Approximately(0, horizontalInput))
        {
            transform.rotation = horizontalInput < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

    }

    bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(_groundCheck.position, 0.5f, _groundLayer))
        {
            _currentJump = 0;
            _animator.SetBool("isJumping", false);
            return true;
        }
        return false;
    }

    void Jump()
    {
        _animator.SetBool("isJumping", true);
        _rigidbody2D.AddForce(new Vector3(0, _jumpForce), ForceMode2D.Impulse);
        _currentJump++;
    }


}

