using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public Vector3 lastCheckpoint;

    void Awake()
    {
        instance = this;
        lastCheckpoint = transform.position;
    }
    public void SetCheckpoint(Vector3 pos)
    {
        lastCheckpoint = pos;
    }
}