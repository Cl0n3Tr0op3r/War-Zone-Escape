using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    public static ExplosionManager Instance; // Singleton instance
    public AudioClip explosionSound; // Assign the explosion sound in the Inspector
    public AudioClip additionalSound; // Assign the additional sound in the Inspector

    private AudioSource explosionAudioSource;
    private AudioSource additionalAudioSource;

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

        // Set up the AudioSource components
        explosionAudioSource = gameObject.AddComponent<AudioSource>();
        explosionAudioSource.clip = explosionSound;
        explosionAudioSource.playOnAwake = false;

        additionalAudioSource = gameObject.AddComponent<AudioSource>();
        additionalAudioSource.clip = additionalSound;
        additionalAudioSource.playOnAwake = false;
    }

    public void PlayExplosionSound(Vector3 position)
    {
        // Move the manager to the explosion location
        transform.position = position;

        // Play both sounds simultaneously
        explosionAudioSource.Play();
        additionalAudioSource.Play();
    }
}
