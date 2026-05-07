using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Player1-only pickup
        if (CompareTag("P1Only") && other.CompareTag("Player1"))
        {
            LevelManager.Instance.PickupCollected();
            Destroy(gameObject);
        }

        // Player2-only pickup
        else if (CompareTag("P2Only") && other.CompareTag("Player2"))
        {
            LevelManager.Instance.PickupCollected();
            Destroy(gameObject);
        }

        // Both players can collect
        else if (CompareTag("Both"))
        {
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                LevelManager.Instance.PickupCollected();
                Destroy(gameObject);
            }
        }
    }
}