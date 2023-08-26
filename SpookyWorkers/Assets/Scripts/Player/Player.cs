using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region VARIABLES

    public bool isWearingTheCostume = false;

    [Header("Movement Setup")]
    [SerializeField] private Vector2 friction;
    [SerializeField] private float speedWalk = 2f;
    [SerializeField] private float jumpForce;

    [Header("Ground Check Setup")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;

    [Header("Dresser Check Setup")]
    [SerializeField] private LayerMask dresserLayer;
    [SerializeField] private Transform dresserCheck;
    [SerializeField] private float dresserCheckRadius;

    [Header("Sprite Setup")]
    [SerializeField] private Color costumeON;
    [SerializeField] private Color costumeOFF;


    private Rigidbody2D _playerRigidbody2D;
    private SpriteRenderer _playerSpriteRenderer;
    private bool _isTouchingTheFloor;
    private bool _isTouchingTheDresser;

    #endregion

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
        HandlePutCustome();

        // the Physics2D.OverlapCircle return a boolean: true if the groundCheck object inside the Player object is touching the floor and false if its not
        _isTouchingTheFloor = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // the Physics2D.OverlapCircle return a boolean: true if the dresserCheck object inside the Player is touching the dresser object in the scene
        _isTouchingTheDresser = Physics2D.OverlapCircle(dresserCheck.position, dresserCheckRadius, dresserLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7 && isWearingTheCostume)
        {
            gameObject.SetActive(false);
        }
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

        // Conditionals to stabilize the player without friction in the floors;
        if (_playerRigidbody2D.velocity.x > 0) _playerRigidbody2D.velocity += friction;
        if (_playerRigidbody2D.velocity.x < 0) _playerRigidbody2D.velocity -= friction;
    }

    // function to the player jump if them its not in the air
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isTouchingTheFloor)
        {
            _playerRigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

    // function that allow the player put the terror costume to scary the clients, if its close to a dresser
    private void HandlePutCustome()
    {
        if (_isTouchingTheDresser)
        {
            if (Input.GetKeyDown(KeyCode.W) && !isWearingTheCostume)
            {
                _playerSpriteRenderer.color = costumeON;
                isWearingTheCostume = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && isWearingTheCostume)
            {
                _playerSpriteRenderer.color = costumeOFF;
                isWearingTheCostume = false;
            }
        }
    }

}
