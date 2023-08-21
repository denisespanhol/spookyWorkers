using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIABLES

    [Header("Movement Setup")]
    [SerializeField] private float speedWalk = 2f;
    [SerializeField] private float jumpForce;

    private Rigidbody2D playerRigidbody2D;

    #endregion

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
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

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

}
