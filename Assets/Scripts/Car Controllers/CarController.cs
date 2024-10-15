using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // values for maxed out car
    // private float steeringMax = 1.5f;
    // private float braking = 10f;
    // private float acceleration = 10f;
    // private float maxSpeed = 200f;

    public InputManager IM;
    public Rigidbody rigidbody;
    // creates an array of 4 wheels
    public WheelCollider[] wheelsCollider;
    public GameObject[] wheelMesh;
    public float torque = 100;
    public float radius = 6f;
    public float downForceValue = 550f;
    public float idleSlowDown = 500f;
    Vector3 wheelPosition = Vector3.zero;
    Quaternion wheelRotation = Quaternion.identity;

    public void moveVehicle(float acceleration, float braking)
    {
        // if player presses throttle
        if (IM.vertical > 0)
        {
            for (int i = 0; i < wheelsCollider.Length; i++)
            {
                wheelsCollider[i].motorTorque = IM.vertical * torque * acceleration;
                // remove brake torque when moving again
                wheelsCollider[i].brakeTorque = 0;
            }
        }
        // if player is braking, using motorTorque still to reverse
        else if (IM.vertical < 0)
        {
            for (int i = 0; i < wheelsCollider.Length; i++)
            {
                wheelsCollider[i].motorTorque = IM.vertical * braking * torque;
                wheelsCollider[i].brakeTorque = 0;
            }
        }
        // if car is idle but has speed
        else if (IM.vertical == 0 && rigidbody.velocity.magnitude > 0.3f)
        {
            for (int i = 0; i < wheelsCollider.Length; i++)
            {
                wheelsCollider[i].brakeTorque = idleSlowDown;
            }
        }
        // if car is idle and speed is 0
        else
        {
            for (int i = 0; i < wheelsCollider.Length; i++)
            {
                wheelsCollider[i].brakeTorque = 0;
            }
        }
    }
    

    public void steering(float steeringMax)
    {
        if (IM.horizontal > 0) 
        {
            wheelsCollider[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * (IM.horizontal * steeringMax);
            wheelsCollider[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * (IM.horizontal * steeringMax);
        } 
        else if (IM.horizontal < 0) 
        {
            wheelsCollider[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * (IM.horizontal * steeringMax);
            wheelsCollider[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * (IM.horizontal * steeringMax);
        } 
        else 
        {
            wheelsCollider[0].steerAngle = 0;
            wheelsCollider[1].steerAngle = 0;
        }   
    }

    public void animateWheels()
    {
        for (int i = 0; i < 4; i++)
        {
            wheelsCollider[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }

    public void addDownForce()
    {
        rigidbody.AddForce(-transform.up * downForceValue * rigidbody.velocity.magnitude);
    }

    public void topSpeed(float maxSpeed)
    {
        // convert kph to m/s
        float metresMax = maxSpeed / 3.6f;
        if (rigidbody.velocity.magnitude > metresMax)
        {
            // keeps the vehicle at its maximum speed
            rigidbody.velocity = rigidbody.velocity.normalized * metresMax;
        }
    }
}
