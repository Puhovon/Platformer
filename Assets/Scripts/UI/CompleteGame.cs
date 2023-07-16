using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private bool canComplete = false;
    
    private void Update()
    {
        if (canComplete && Input.GetKey(KeyCode.E))
            SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        text.text = "Press [E]";
        canComplete = true;
    }
}
