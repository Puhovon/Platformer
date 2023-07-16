using System.Collections;
using Cinemachine;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Collider2D[] configs;
    [SerializeField]private Transform[] _teleportTo;


    private CinemachineConfiner _camera;
    private Animator _playerAnimator;
    private CompleteLevel _completeLevel;

    private int currentTeleport = 0;


    private void Awake()
    {
        _playerAnimator = player.GetComponent<Animator>();
        _completeLevel = GameObject.FindWithTag("GameController").GetComponent<CompleteLevel>();
        _camera = GameObject.Find("Virtual Camera").GetComponent<CinemachineConfiner>();
    }

    public IEnumerator Teleporting()
    {
        _playerAnimator.SetTrigger("Teleport");
        yield return new WaitForSeconds(1);
        player.transform.position = _teleportTo[_completeLevel.CountOfTeleport].position;
        _camera.m_BoundingShape2D = configs[_completeLevel.CountOfTeleport];
        _completeLevel.CountOfTeleport += 1;
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
    }
}
