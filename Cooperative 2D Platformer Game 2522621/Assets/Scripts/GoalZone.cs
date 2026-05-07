using UnityEngine;

public class GoalZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            LevelManager.Instance.PlayerEnteredGoal(other.tag);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            LevelManager.Instance.PlayerExitedGoal(other.tag);
        }
    }
}