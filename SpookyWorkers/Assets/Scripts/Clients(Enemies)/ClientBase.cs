using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientBase : MonoBehaviour
{
    [Header("Client Setup")]
    [SerializeField] private float speedRunClient = 2f;


    private GameObject _doorObject;
    private PlayerSkills _playerSkillsScript;

    private void Awake()
    {
        _playerSkillsScript = GameObject.Find("Player").GetComponent<PlayerSkills>();
        _doorObject = GameObject.Find("Door");
    }

    private void Update()
    {
        ClientsScared();
    }

    private void ClientsScared()
    {
        if (tag == _playerSkillsScript.clientScaredTag)
        {
            transform.position = Vector2.MoveTowards(transform.position, _doorObject.transform.position, speedRunClient * Time.deltaTime);
        } 
    }
}
