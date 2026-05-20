using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;    

        activated = true;
        CheckpointManager.instance.SetCheckpoint(transform.position);
    }
}