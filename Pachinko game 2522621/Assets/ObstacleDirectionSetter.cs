using UnityEngine;

public class ObstacleDirectionSetter : MonoBehaviour
{
    void Start()
    {
        MovingObstacle[] obstacles = FindObjectsOfType<MovingObstacle>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            int dir = (i % 2 == 0) ? -1 : 1; 
            obstacles[i].SetInitialDirection(dir);
        }
    }
}