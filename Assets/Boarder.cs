using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boarder : MonoBehaviour
{
    PlayerMovement _player;

    GameManager _gameManager;

    public void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            _gameManager.RestartScene();
        }
    }
}
