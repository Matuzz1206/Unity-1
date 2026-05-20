using UnityEngine;

public class WinZone : MonoBehaviour
{
    public GameObject winPanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}