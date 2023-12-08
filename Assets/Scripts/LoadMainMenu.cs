using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private float delay = 7f; // delay in seconds
    private string scene = "Main Menu"; // scene name to change to
    void Start()
    {
        StartCoroutine(LoadLMainMenuAfterDelay(delay)); //calls functions
    }

    IEnumerator LoadLMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(scene); // loads scene after waiting
    }
}