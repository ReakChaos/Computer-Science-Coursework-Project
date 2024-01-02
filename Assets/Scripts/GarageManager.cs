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
    public int vehiclePointer = 0;
    public float rotateSpeed = 10;
    // stores the car object
    private GameObject childObject;
    // position for cars that are lower
    private Vector3 spawnLocation = new (0f, 0.9f, 0f);

    private void Awake()
    {
        // immediately instantiates the car in the list
        childObject =
            Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity);
        // making it a child object to the toRotate object
        childObject.transform.parent = toRotate.transform;
    }

    // FixedUpdate used for smoother motion as it is based on framerate
    private void FixedUpdate()
    {
        // rotates the car and stand
        toRotate.transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
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
            DestroyCar();
            vehiclePointer++;
            // car3 and car4 are actually lower to the ground so have to make it higher, and car4 is 180 degrees wrong
            if (vehiclePointer == 2)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, Quaternion.identity);
            }
            else if (vehiclePointer == 3)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, Quaternion.Euler(0f, 180f, 0f) );
            }
            else
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity);
            }
            childObject.transform.parent = toRotate.transform;
        }
    }

    public void leftButton()
    {
        // pointer has to be higher than 0
        if (vehiclePointer > 0)
        {
            DestroyCar();
            vehiclePointer--;
            if (vehiclePointer >= 2)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, Quaternion.identity);
            }
            else if (vehiclePointer == 3)
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], spawnLocation, Quaternion.Euler(0f, 180f, 0f) );
            }
            else
            {
                childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity);
            }
            childObject.transform.parent = toRotate.transform;
        }
    }
}
