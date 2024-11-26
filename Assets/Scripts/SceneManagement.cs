using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManagement : MonoBehaviour
{
    [Header("Scene Transition Settings")]

    [Tooltip("Name of the scene to load when the Space key is pressed.")]
    public string spaceKeySceneName = "Start Cutscene";

    [Tooltip("Name of the scene to load when the Escape key is pressed.")]
    public string escapeKeySceneName = "TitleScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadScene(spaceKeySceneName);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene(escapeKeySceneName);
        }
    }

    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="sceneName">Name of the scene to load.</param>
    private void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
