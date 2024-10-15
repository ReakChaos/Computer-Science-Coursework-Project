using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car4Controller : CarController
{
    public float steeringMax = 0.9f;
    public float braking = 8.4f;
    public float acceleration = 6.5f;
    public float maxSpeed = 188;
    
    public void Awake()
    {
        // gets the components for the input manager and the rigid body
        IM = GetComponent<InputManager>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        addDownForce();
        animateWheels();
        moveVehicle(acceleration, braking);
        steering(steeringMax);
        topSpeed(maxSpeed);
    }
}
