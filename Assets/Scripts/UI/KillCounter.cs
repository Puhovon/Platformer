using System;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text killText;
    
    private int killCount = 0;

    public int GetKillCount
    {
        get { return killCount; }
    }
    private void Start()
    {
        killText.text = $"Kills: {killCount}";
    }

    public void IncreaseCounter()
    {
        killCount++;
        killText.text = $"Kills: {killCount}";
    }
}
