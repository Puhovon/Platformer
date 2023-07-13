using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTo;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject player;

    private Animator _playerAnimator;

    private bool onTrigger = false;
    private int count = 0;

    private void Awake()
    {
        _playerAnimator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (onTrigger && Input.GetKey(KeyCode.E) && count < 1)
        {
            count++;
            StartCoroutine(Teleporting());
        }    
    }

    private IEnumerator Teleporting()
    {
        _playerAnimator.SetTrigger("Teleport");    
        yield return new WaitForSeconds(1);
        player.transform.position = teleportTo.position;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = true;
            text.text = "Press [E] to teleport";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onTrigger = false;
            text.text = "";
        }
    }
}
