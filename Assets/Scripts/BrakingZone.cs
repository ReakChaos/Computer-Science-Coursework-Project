using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakingZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AICarController car = other.GetComponent<AICarController>();
        if (car)
        {
            car.isInsideBreaking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AICarController car = other.GetComponent<AICarController>();
        if (car)
        {
            car.isInsideBreaking = false;
        }
    }
}
