using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _waitTime;

    [SerializeField] int _radius;
    [SerializeField] Transform _playerTransform;
    [Tooltip("Path the Enemy will follow")]
    [SerializeField] Transform[] _waypoints;

    int _currentWaypointIndex = 0;
    PlayerMovement _player;


    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
        StartCoroutine(Patrol());
    }

    //When next waypoint is reached loop and go to the next point
    IEnumerator Patrol()
    {
        Transform waypoint = _waypoints[_currentWaypointIndex];
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y); // Flips sprite
        while (Vector3.Distance(transform.position, waypoint.position) > 0.01f)
        {
            if (Vector3.Distance(transform.position, _playerTransform.position) <= _radius)
                transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = waypoint.position;
        
        yield return new WaitForSeconds(_waitTime);
        _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        StartCoroutine(Patrol());
    }

   
}
