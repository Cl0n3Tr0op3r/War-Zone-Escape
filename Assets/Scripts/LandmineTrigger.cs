using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollisionExplosion : MonoBehaviour
{
    public Transform explosionPrefab;
    public float reloadDelay = 0.25f; // Delay before reloading the scene

    private void OnCollisionEnter(Collision collision)
    {
        // Spawn explosion visual effect at current position and rotation
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        // Play the explosion sound through the ExplosionManager
        ExplosionManager.Instance.PlayExplosionSound(transform.position);

        // Start coroutine to handle explosion and reload the scene
        StartCoroutine(HandleExplosionAndReload());
    }

    // Coroutine to reload the scene after a delay and destroy the object
    private IEnumerator HandleExplosionAndReload()
    {
        yield return new WaitForSeconds(reloadDelay); // Wait for the specified delay

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Destroy the mine object AFTER scene reload is triggered
        Destroy(gameObject);
    }
}
