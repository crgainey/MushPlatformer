using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Health _health;
    PlayerMovement _player;
    EnemyPlatformMovement _enemyPlatform;
    EnemyWaypointMovement _enemyWaypoint;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _health = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            _health.TakeDamage();
        }

    }



}
