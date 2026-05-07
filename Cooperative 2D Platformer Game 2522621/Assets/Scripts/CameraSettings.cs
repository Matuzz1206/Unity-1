using UnityEngine;

public class CameraFollowBothPlayers : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        Vector3 desiredPosition = midpoint + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}