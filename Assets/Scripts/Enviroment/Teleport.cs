using System;
using System.Collections;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D nextConfig;
    [SerializeField]private Transform _teleportTo;


    private CinemachineConfiner _camera;
    private Animator _playerAnimator;
    private CompleteLevel _completeLevel;


    private void Awake()
    {
        _playerAnimator = player.GetComponent<Animator>();
        _completeLevel = GameObject.FindWithTag("GameController").GetComponent<CompleteLevel>();
        _camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineConfiner>();
        Debug.Log($"Teleport to: {_teleportTo.name} from {transform.name}");
    }

    public void StartTeleporting()
    {
        StartCoroutine(Teleporting());
    }
    private IEnumerator Teleporting()
    {
        _playerAnimator.SetTrigger("Teleport");
        yield return new WaitForSeconds(1);
        player.transform.position = _teleportTo.position;
        Debug.Log($"Player position: {player.transform.position}\nTeleportTo name: {_teleportTo.name}" +
                  $"TeleportTo position: {_teleportTo.position}");
        _teleportTo.GetComponentInChildren<ParticleSystem>().Play();
        _camera.m_BoundingShape2D = nextConfig;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _completeLevel.CanOpen = true;
            _completeLevel.OpenPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _completeLevel.CanOpen = false;
        } 
        StopAllCoroutines();
    }
}
