using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoSceneSwitcher : MonoBehaviour
{
    public float delayBeforeSwitch = 10f; // Time in seconds before switching scenes
    public string sceneToLoad = "MyNextScene"; // Replace with the actual scene name

    private void Start()
    {
        StartCoroutine(SwitchSceneAfterDelay());
    }

    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSwitch);
        SceneManager.LoadScene(sceneToLoad);
    }
}
