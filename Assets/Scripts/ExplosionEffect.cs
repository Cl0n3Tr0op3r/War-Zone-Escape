using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public float explosionTime = 1.0f;   // Time before destroying explosion
    public float explosionRadius = 5.0f; // Radius of explosion effect
    public float explosionPower = 2000.0f; // Force of explosion

    private void Start()
    {
        // Destroy this explosion object after 'explosionTime' seconds
        Destroy(gameObject, explosionTime);

        // Find all colliders in the explosion radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // If the collider has a Rigidbody, apply explosion force
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(explosionPower, transform.position, explosionRadius);
            }
        }

        // Handle particle emission (if there's a particle system attached)
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            // Start emitting particles
            particleSystem.Play();
        }
    }
}
