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

        // All objects with the layer Client will not collide with each other
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Desactivate the clients when they collide with the door
        if (collision.CompareTag("Door")) gameObject.SetActive(false);
    }

    // Function to move the clients to the door when they get scared, using the tag as a comparator
    private void ClientsScared()
    {
        if (tag == _playerSkillsScript.clientScaredTag)
        {
            transform.position = Vector2.MoveTowards(transform.position, _doorObject.transform.position, speedRunClient * Time.deltaTime);
        } 
    }
}
