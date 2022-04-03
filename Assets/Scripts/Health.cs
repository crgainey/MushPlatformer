using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    int _health = 3;
    int _numOfHearts = 3;


    [SerializeField] Image[] _hearts;
    [SerializeField] Sprite _fullHeart;
    [SerializeField] Sprite _emptyHeart;

    GameManager _gameManager;

    public void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage()
    {
        _health--;
        LoseHeart();
    }

    void LoseHeart()
    {
        if(_health <= 0)
        {
            _gameManager.RestartScene();
        }

        for (int i = 0; i < _hearts.Length; i++)
        {
            if(i < _health)
            {
                _hearts[i].sprite = _fullHeart;
            }
            else
            {
                _hearts[i].sprite = _emptyHeart;
            }

            if(i < _numOfHearts)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }

    }



}
