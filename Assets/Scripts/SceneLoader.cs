using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public void LoadScene(string SceneName) // Input for the scene to load
    {
        StartCoroutine(LoadAsync(SceneName)); // Calling the coroutine as it is asynchronously
    }

    IEnumerator LoadAsync(string SceneName) // The coroutine loading the scene in the background
    {
        // Making a variable to represent the scene loading, accessing information about it
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        
        loadingScreen.SetActive(true);
        
        while (!operation.isDone) // While the scene is not loaded 
        {
            // Clamps value of progress to 0 - 1 as operation.progress is only from 0 - 0.9
            float progress = Math.Clamp(operation.progress / 0.9f, 0, 1);
            progressText.text = progress * 100f + "%";
            slider.value = progress;

            yield return null;
        }
    }
}