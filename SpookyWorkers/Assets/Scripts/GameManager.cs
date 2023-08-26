using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] clientObjects;

    private GameObject _playerObject;

    private void Awake()
    {
        _playerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (!_playerObject.activeInHierarchy) Debug.Log("Game Over");
    }
}
