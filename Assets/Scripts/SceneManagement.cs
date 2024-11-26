using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManagement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadCutscene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadTitle();
        }
    }

    public void LoadCutscene()
    {
        string sceneName = "Start Cutscene";
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Please check the scene name and ensure it is added to the Build Settings.");
        }
    }
    public void LoadTitle()
    {
        string sceneName = "Start Cutscene";
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' cannot be loaded. Please check the scene name and ensure it is added to the Build Settings.");
        }
    }
}