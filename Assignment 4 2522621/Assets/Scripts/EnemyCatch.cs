using UnityEngine;

public class EnemyCatch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Lose();
        }
    }
}