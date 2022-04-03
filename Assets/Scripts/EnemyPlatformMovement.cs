using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _radius;

    [SerializeField] Transform groundCheck; // checks enemy has hit end of platform 
    [SerializeField] LayerMask groundLayer;
    bool _turn;

    Rigidbody2D _rigidbody2D;
    BoxCollider2D _boxCollider;

    PlayerMovement _player;
    [SerializeField] Transform _playerTransform;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Patrol();
        
        _turn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); // Checks if enemy has reached edge.
    }
    
    // Patrols the length of the platform the enmy is on 
    void Patrol()
    {
        if (_turn)
        {
            Flip();
        }

        _rigidbody2D.velocity = new Vector2(_speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);
    }

    // Flips enemy to face opposeite way at end of platform 
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        _speed *= -1; // Switches value back to positive 
    }
}
