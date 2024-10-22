using UnityEngine;

public class CollisionExplosion : MonoBehaviour
{
    public Transform explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        // Spawn explosion at current position and rotation
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        // Destroy this object after the explosion is instantiated
        Destroy(gameObject);
    }
}
