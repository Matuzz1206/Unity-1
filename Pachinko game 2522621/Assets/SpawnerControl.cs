using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    public GameObject ballPrefab;
    public float moveSpeed = 5f;

    public float minX = -6.7f;
    public float maxX = 6.7f;
    public float fixedY = 4.5f;

    public bool ballActive = false; 

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            fixedY,
            0f
        );
        float input = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(input, 0f, 0f) * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && !ballActive)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ballActive = true; 
        }
    }
}