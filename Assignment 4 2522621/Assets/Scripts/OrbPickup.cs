using UnityEngine;

public class OrbPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddOrb();
            Destroy(gameObject);
        }
    }
}