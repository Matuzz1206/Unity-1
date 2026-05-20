using UnityEngine;

public class Catapult : MonoBehaviour
{
    public float delay = 3f;
    public float launchForce = 20f;
    bool activated;

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;

        activated = true;
        StartCoroutine(Launch(other));
    }

    System.Collections.IEnumerator Launch(Collider player)
    {
        yield return new WaitForSeconds(delay);

        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.AddExternalForce(Vector3.up * launchForce);
        }

        activated = false;
    }
}