using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] clientObjects;
    public bool isGamePaused = false;

    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private GameObject pausedGameObject;
    private GameObject _playerObject;

    private void Awake()
    {
        _playerObject = GameObject.Find("Player");

    }

    private void Update()
    {
        GameOver();
        ToControlPauseBoolean();
    }

    private void GameOver()
    {
        if (!_playerObject.activeInHierarchy) gameOverObject.SetActive(true);
    }

    private void ToControlPauseBoolean()
    {
        if (Time.timeScale == 0)
        {
            isGamePaused = true;
            pausedGameObject.SetActive(true);
        }    

        else if (Time.timeScale == 1)
        {
            isGamePaused = false;
            pausedGameObject.SetActive(false);
        }
    }
}
