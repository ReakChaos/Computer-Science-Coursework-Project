using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GarageManager : MonoBehaviour
{
    // collects the object to be rotated and the list of vehicles 
    public GameObject toRotate;
    public VehicleList listOfVehicles;
    public CarInfoList listOfPanels;
    public GameObject selectCheck;
    public GameObject selectButton;
    public GameObject lockImage;
    private Button ButtonSelect;
    private int vehiclePointer = 0;
    private float rotateSpeed = 10;
    private int selectedCounter = 0;
    // stores the car object
    private GameObject childObject;
    // position for cars that are lower
    private Vector3 spawnLocation = new (0f, 0.9f, 0f);
    private Quaternion qAngle;

    private void Awake()
    {
        PlayerPrefs.SetInt("Level", 3);
        // gets button component of the select button
        ButtonSelect = selectButton.GetComponent<Button>();
        // initialises the selected counter with the player pref
        selectedCounter = PlayerPrefs.GetInt("selectedCar");
        // checks if the user has selected another car before
        if (selectedCounter != 0)
        {
            selectCheck.SetActive(false);
            selectButton.SetActive(true);
        }
        // panel for the first car is loaded
        listOfPanels.panels[vehiclePointer].SetActive(true);
        // immediately instantiates the car in the list, flipping it to face forward
        childObject =
            Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity* Quaternion.Euler(0f, 180f, 0f));
        // making it a child object to the toRotate object
        childObject.transform.parent = toRotate.transform;
    }

    // FixedUpdate used for smoother motion as it is based on framerate
    private void FixedUpdate()
    {
        // rotates the car and stand
        toRotate.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        Vector3 vectorAngle = toRotate.transform.eulerAngles;
        // flipping it to face forward
        qAngle = Quaternion.Euler(vectorAngle) * Quaternion.Euler(0f, 180f, 0f);
    }

    private void DestroyCar()
    {
        Destroy(childObject);
    }

    public void rightButton()
    {
        // pointer has to be less than max length
        if (vehiclePointer < listOfVehicles.vehicles.Length - 1)
        {
            // removes car and the respective panel
            DestroyCar();
            listOfPanels.panels[vehiclePointer].SetActive(false);
            vehiclePointer++;

            // loads correct panel
            listOfPanels.panels[vehiclePointer].SetActive(true);
            // car3 and car4 are actually lower to the ground so have to make it higher
            if (vehiclePointer == 2)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, qAngle);
            }
            // car4 is also 180 degrees flipped
            else if (vehiclePointer == 3)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, qAngle * Quaternion.Euler(0f, 180f, 0f));
            }
            else
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, qAngle);
 
            }
            childObject.transform.parent = toRotate.transform;

            // if the player hasnt unlocked the level matching the car number, lock the car
            if (PlayerPrefs.GetInt("Level") < vehiclePointer + 1)
            {
                lockImage.SetActive(true);
                ButtonSelect.interactable = false;
            }
            else
            {
                lockImage.SetActive(false);
                ButtonSelect.interactable = true;
            }
            
            // if the car is not the selected car turn off the check mark and enable the button and vise versa
            if (vehiclePointer != selectedCounter)
            {
                selectCheck.SetActive(false);
                selectButton.SetActive(true);
            }
            else
            {
                selectCheck.SetActive(true);
                selectButton.SetActive(false);
            }
        }
    }

    // same as rightButton just decrementing the pointer
    public void leftButton()
    {
        // pointer has to be higher than 0
        if (vehiclePointer > 0)
        {
            listOfPanels.panels[vehiclePointer].SetActive(false);
            DestroyCar();
            vehiclePointer--;
            
            listOfPanels.panels[vehiclePointer].SetActive(true);
            if (vehiclePointer == 2)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, qAngle);
            }
            else if (vehiclePointer == 3)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, qAngle * Quaternion.Euler(0f, 180f, 0f));
            }
            else
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, qAngle);
            }
            childObject.transform.parent = toRotate.transform;
            
            if (PlayerPrefs.GetInt("Level") < vehiclePointer + 1)
            {
                lockImage.SetActive(true);
                ButtonSelect.interactable = false;
            }
            else
            {
                lockImage.SetActive(false);
                ButtonSelect.interactable = true;
            }
            
            if (vehiclePointer != selectedCounter)
            {
                selectCheck.SetActive(false);
                selectButton.SetActive(true);
            }
            else
            {
                selectCheck.SetActive(true);
                selectButton.SetActive(false);
            }
        }
        
    }
    // when the select button is pressed
    public void onSelectClick()
    {
        // save which car is selected
        selectedCounter = vehiclePointer;
        
        // select check should appear and the button would disappear
        selectCheck.SetActive(true);
        selectButton.SetActive(false);
        
        // stores the selected car in file
        PlayerPrefs.SetInt("selectedCar", selectedCounter);
    }
}
