using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject explosionEffect; 

    private void OnDestroy()
    {
        FindObjectOfType<SpawnerControl>().ballActive = false;
    }
    public void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}