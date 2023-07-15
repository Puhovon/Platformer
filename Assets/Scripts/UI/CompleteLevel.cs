using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text text;

    private KillCounter _killCounter;
    private Teleport _teleport;
    private Animator _panelAnimator;

    private bool canOpen = false;
    public bool CanOpen
    {
        set { canOpen = value; }
    }

    private void PanelActive() => panel.SetActive(false);

    private void Start()
    {
        _teleport = GameObject.FindWithTag("Teleport").GetComponent<Teleport>();
        _killCounter = GetComponent<KillCounter>();
        _panelAnimator = panel.GetComponent<Animator>();
    }

    public void OpenPanel()
    {
        if (canOpen)
        {
            panel.SetActive(true);
            _panelAnimator.SetTrigger("Open");
            text.text = $"you killed {_killCounter.GetKillCount} monsters!";
        }
    }

    private void Update()
    {
        if (canOpen)
        {
            if (Input.GetKey(KeyCode.E))
            {
                _teleport.StartTeleporting();
                canOpen = false;
                _panelAnimator.SetTrigger("Close");
                panel.SetActive(false);
            }
        }
    }
}
