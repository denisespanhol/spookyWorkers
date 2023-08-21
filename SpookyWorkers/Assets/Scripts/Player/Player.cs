using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float speedWalk = 2f;

    private Rigidbody2D playerRigidbody2D;

    #endregion

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
    }

    // function to control the players horizontal movement
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody2D.velocity = new Vector2(speedWalk, playerRigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody2D.velocity = new Vector2(-speedWalk, playerRigidbody2D.velocity.y);
        }
    }

}
