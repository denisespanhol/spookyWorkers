using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBase : MonoBehaviour
{
    [Header("Client Setup")]
    [SerializeField] private Vector2 doorPosition;
    [SerializeField] private float speedRunClient;


    private PlayerSkills _playerSkillsScript;

    private void Awake()
    {
        _playerSkillsScript = GameObject.Find("Player").GetComponent<PlayerSkills>();
    }

    private void Update()
    {
        ClientsScared();
    }

    private void ClientsScared()
    {
        if (tag == _playerSkillsScript.clientScaredTag)
        {
            
        } 
    }
}
