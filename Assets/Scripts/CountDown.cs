using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI countDown;

    private void Start()
    {
        // disables the car controller for both the user and AI
        GameObject.FindWithTag("Player").GetComponent<CarController>().enabled = false;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
        GameObject[] cars = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject car in cars)
        {
            car.GetComponent<AICarController>().enabled = false;
        }
        // starts the countdown
        StartCoroutine(CountDownRoutine());
    }
    IEnumerator CountDownRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        countDown.text = "3";
        
        yield return new WaitForSeconds(1f);
        countDown.text = "2";
        
        yield return new WaitForSeconds(1f);
        countDown.text = "1";
        
        yield return new WaitForSeconds(1f);
        countDown.text = "GO!";
        GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().enabled = true;
        yield return new WaitForSeconds(1f);
        
        // removes the countdown text after countdown
        canvas.SetActive(false);
        
        // enables the car controller for both the user and AI
        GameObject.FindWithTag("Player").GetComponent<CarController>().enabled = true;
        GameObject[] cars = GameObject.FindGameObjectsWithTag("AI");
        foreach (GameObject car in cars)
        {
            car.GetComponent<AICarController>().enabled = true;
        }
    }
}


