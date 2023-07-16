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
    private int countOfTeleport = 0;
    public bool CanOpen
    {
        get { return canOpen;}
        set { canOpen = value; }
    }

    public int CountOfTeleport
    {
        get { return countOfTeleport; }
        set { countOfTeleport = value; }
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
                canOpen = false;
                StartCoroutine(_teleport.Teleporting());
                panel.SetActive(false);
            }
        }
    }
}
