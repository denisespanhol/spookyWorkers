using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIABLES

    [Header("Movement Setup")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float speedWalk = 2f;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _playerRigidbody2D;
    private bool _isTouchingTheFloor;

    #endregion

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();

        // the Physics2D.OverlapCircle return a boolean: true if the groundCheck object inside the Player object is touching the floor and false if its not
        _isTouchingTheFloor = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // function to control the players horizontal movement
    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _playerRigidbody2D.velocity = new Vector2(speedWalk, _playerRigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerRigidbody2D.velocity = new Vector2(-speedWalk, _playerRigidbody2D.velocity.y);
        }
    }

    // function to the player jump if them its not in the air
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isTouchingTheFloor)
        {
            _playerRigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

}
