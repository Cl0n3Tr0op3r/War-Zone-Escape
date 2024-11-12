using UnityEngine;
using System.Collections;

public class AutoQuitApplication : MonoBehaviour
{
    public float delayBeforeQuit = 5f; // Time in seconds before quitting the application

    private void Start()
    {
        StartCoroutine(QuitAfterDelay());
    }

    private IEnumerator QuitAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeQuit);

        // Quit the application
        Application.Quit();
        
        // For testing in the editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
