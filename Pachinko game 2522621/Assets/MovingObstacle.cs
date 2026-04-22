using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float leftLimit = -3f;
    public float rightLimit = 3f;

    private int direction = 1; 

    public void SetInitialDirection(int dir)
    {
        direction = dir;
    }
    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        if (transform.position.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
            direction = -1;
        }

        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
            direction = 1;
        }
    }
}