using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}