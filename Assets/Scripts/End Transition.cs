using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderSoundAndSceneSwitch : MonoBehaviour
{
    public AudioClip soundEffect; // Drag your sound effect here in the inspector
    public string sceneToLoad; // Enter the name of the scene you want to load

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
        audioSource.clip = soundEffect;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Play the sound effect
        if (soundEffect != null && audioSource != null)
        {
            audioSource.Play();
        }

        // Load the specified scene after the sound effect has finished playing
        Invoke("LoadScene", soundEffect.length);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
