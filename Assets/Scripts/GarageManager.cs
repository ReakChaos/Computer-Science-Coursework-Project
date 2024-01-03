using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GarageManager : MonoBehaviour
{
    // collects the object to be rotated and the list of vehicles 
    public GameObject toRotate;
    public VehicleList listOfVehicles;
    public CarInfoList listOfPanels;
    public int vehiclePointer = 0;
    public float rotateSpeed = 10;
    // stores the car object
    private GameObject childObject;
    // position for cars that are lower
    private Vector3 spawnLocation = new (0f, 0.9f, 0f);
    private Quaternion qAngle;

    private void Awake()
    {
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
        }
    }
}
