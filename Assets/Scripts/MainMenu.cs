using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void RaceDay()
    {
        SceneManager.LoadScene("Race Day");
    }

    public void Career()
    {
        SceneManager.LoadScene("Career");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
