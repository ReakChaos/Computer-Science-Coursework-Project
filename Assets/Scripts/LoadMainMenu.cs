using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private float delay = 7f; // delay in seconds
    private string scene = "Main Menu"; // scene name to change to
    void Start()
    {
        // first time loading
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            // set level to 1
            PlayerPrefs.SetInt("Level", 1);
        }
        StartCoroutine(LoadLMainMenuAfterDelay(delay)); //calls functions
        
    }

    IEnumerator LoadLMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(scene); // loads scene after waiting
    }
}