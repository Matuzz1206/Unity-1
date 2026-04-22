using UnityEngine;
public class Slot : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.AddScore(scoreValue);

            other.GetComponent<Ball>().Explode();
        }
    }
}