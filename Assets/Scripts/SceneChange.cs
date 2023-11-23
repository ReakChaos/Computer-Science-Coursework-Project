using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float delay = 10;
    public string scene = "Main Menu";
    void Start()
    {
        StartCoroutine(LoadLMainMenuAfterDelay(delay));
    }

    IEnumerator LoadLMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}