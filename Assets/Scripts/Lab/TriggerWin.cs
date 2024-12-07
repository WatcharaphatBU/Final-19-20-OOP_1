using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public TMP_Text WinText;
    public string winMessage = "You Win! Happy Happy!";

    void Start()
    {
        WinText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WinText.text = winMessage;
            WinText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}