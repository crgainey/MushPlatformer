using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] Image _key;
    [SerializeField] Sprite _fullKey;

    PlayerMovement _player;
    GameManager _gameManager;

    public void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player.gameObject)
        {
            _key.sprite = _fullKey;
            _gameManager.HasKey = true;
            Destroy(gameObject);
        }
    }
}
