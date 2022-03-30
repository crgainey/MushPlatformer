using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    PlayerMovement _player;
    GameManager _gameManager;
    [SerializeField] int LevelToLoad;

    public void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<PlayerMovement>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject && (_gameManager.HasKey == true))
        {
            if(LevelToLoad == 1)
            {
                _gameManager.LoadLevelOne();
            }
            else if (LevelToLoad == 2)
            {
                _gameManager.LoadLevelTwo();
            }
            else
            {
                _gameManager.MainMenu();
            }
            
        }
    }
}
