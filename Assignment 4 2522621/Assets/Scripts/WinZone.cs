using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Won:DDD");
            Debug.Log("Restarting Level...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}