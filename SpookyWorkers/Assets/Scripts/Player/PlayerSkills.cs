using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSkills : MonoBehaviour
{

    private Player _playerScript;
    private bool _isScarySkillReady = true;
    private float secondsToScaryAgain = 2f;

    // DOTween variables
    private float duration = 2f;
    private float strength = 2f;
    private float randomness = 60;
    private int vibrato = 10;
    private bool fadeOut = true;
    private ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Harmonic;

    private void Awake()
    {
        _playerScript = GetComponent<Player>();

        DOTween.Init();
    }

    private void Update()
    {
        skillToScary();
    }

    // Function that allow the player to scary clients when P is pressed
    private void skillToScary()
    {
        if (Input.GetKeyDown(KeyCode.P) && _playerScript.isWearingTheCostume && _isScarySkillReady)
        {
            transform.DOShakeScale(duration, strength, vibrato, randomness, fadeOut, randomnessMode);
            _isScarySkillReady = false;
            StartCoroutine(scaryInterval());
        }
    }

    private IEnumerator scaryInterval()
    {
        yield return new WaitForSeconds(secondsToScaryAgain);

        _isScarySkillReady = true;
    }
}
