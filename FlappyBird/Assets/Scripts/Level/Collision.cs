using System;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Player _player;
    private BackgroundScroll _backgroundScroll;
    private EnviromentMove _enviromentMove;
    [SerializeField] private float timeToInvoke;
    private GameObject _gameObject;
    private bool playSound = true;

    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
        _backgroundScroll = FindAnyObjectByType<BackgroundScroll>();
        _enviromentMove = FindAnyObjectByType<EnviromentMove>();
        _gameObject = GameObject.FindGameObjectWithTag("Enviroment");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playSound)
        {
            _gameObject.GetComponent<AudioSource>().Play();
            playSound = false;
        }

        _player.playerIsAlive = false;
        _enviromentMove.obstaclesIsMoving = false;
        _backgroundScroll.backgroundIsScrolling = false;
        StartCoroutine(InvokeStaticMethod.ReloadWithDelay(timeToInvoke, ReloadScene.LoadLevel));
    }
}