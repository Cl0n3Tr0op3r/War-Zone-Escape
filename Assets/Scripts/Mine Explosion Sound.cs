using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public static ExplosionManager Instance; // Singleton instance
    public AudioClip explosionSound; // Assign the explosion sound in the Inspector

    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure there's only one instance of ExplosionManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep it across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Set up the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = explosionSound;
        audioSource.playOnAwake = false; // Don't play automatically
    }

    public void PlayExplosionSound(Vector3 position)
    {
        // Move the manager to the explosion location and play sound
        transform.position = position;
        audioSource.Play();
    }
}
