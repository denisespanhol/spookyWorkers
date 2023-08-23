using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSkills : MonoBehaviour
{
    #region VARIABLES
    [Header("Scary's Setup")]
    [SerializeField] private LayerMask clientLayers;
    [SerializeField] private Transform scaryPoint;
    [SerializeField] private float scaryRange;

    private Player _playerScript;
    private GameManager _gameManagerScript;
    private Collider2D[] hitClients;
    private bool _isScarySkillReady = true;
    private float secondsToScaryAgain = 2f;
    private string clientScaredTag = "clientScared";

    // DOTween variables
    private float duration = 2f;
    private float strength = 2f;
    private float randomness = 60;
    private int vibrato = 10;
    private bool fadeOut = true;
    private ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Harmonic;
    #endregion

    private void Awake()
    {
        _playerScript = GetComponent<Player>();
        _gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Initializing Dotween
        DOTween.Init();
    }

    private void Update()
    {
        skillToScary();
    }

    // Function to draw a circle in the scary point area, in unity scene
    private void OnDrawGizmosSelected()
    {
        if (scaryPoint == null) return;

        Gizmos.DrawWireSphere(scaryPoint.position, scaryRange);
    }

    // Function that allow the player to scary clients when P is pressed
    private void skillToScary()
    {   
        // Capture all the colliders2D inside the scary point area
        hitClients = Physics2D.OverlapCircleAll(scaryPoint.position, scaryRange, clientLayers);

        if (Input.GetKeyDown(KeyCode.P) && _playerScript.isWearingTheCostume && _isScarySkillReady)
        {
            transform.DOShakeScale(duration, strength, vibrato, randomness, fadeOut, randomnessMode);
            _isScarySkillReady = false;
            StartCoroutine(scaryInterval());

            // Compares the Collider2D object names with the name of the clients gameObject in the Game Manager 
            foreach (Collider2D client in hitClients)
            {
                foreach (GameObject clientObject in _gameManagerScript.clientObjects)
                {
                    if (client.name == clientObject.name) clientObject.tag = clientScaredTag;
                } 
            }
        }
    }

    // Coroutine to put an interval in the scary skill use
    private IEnumerator scaryInterval()
    {
        yield return new WaitForSeconds(secondsToScaryAgain);

        _isScarySkillReady = true;
    }
}
