using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject[] racePanels;
    private bool clicked = false; // variable checking if a race button has been already pressed
    private int panelNumber; // stores last panel number displayed
    public GameObject defaultNav;
    public GameObject onRaceNav;

    // when a race button is clicked
    public void RaceButtonClicked()
    {
        defaultNav.SetActive(false);
        onRaceNav.SetActive(true);
        clicked = true;

    }
    
    // when the back button is pressed
    public void BackButtonClicked()
    {
        // reset the clicked variable/navigation and close panels
        clicked = false;
        racePanels[panelNumber].SetActive(false);
        defaultNav.SetActive(true);
        onRaceNav.SetActive(false);
    }

    public void RaceButton1()
    {
        // if any button has been clicked before disable previous panel
        if (clicked)
        {
            racePanels[panelNumber].SetActive(false);
        }
        // and open current panel
        racePanels[0].SetActive(true);
        panelNumber = 0;
    }
    public void RaceButton2()
    {
        if (clicked)
        {
            racePanels[panelNumber].SetActive(false);
        }
        racePanels[1].SetActive(true);
        panelNumber = 1;
    }
    public void RaceButton3()
    {
        if (clicked)
        {
            racePanels[panelNumber].SetActive(false);
        }
        racePanels[2].SetActive(true);
        panelNumber = 2;
    }
    public void RaceButton4()
    {
        if (clicked)
        {
            racePanels[panelNumber].SetActive(false);
        }
        racePanels[3].SetActive(true);
        panelNumber = 3;
    }
    public void RaceButton5()
    {
        if (clicked)
        {
            racePanels[panelNumber].SetActive(false);
        }
        racePanels[4].SetActive(true);
        panelNumber = 4;
    }
}
