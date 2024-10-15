using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2Controller : CarController
{
    public float steeringMax = 0.7f;
    public float braking = 4.0f;
    public float acceleration = 6.2f;
    public float maxSpeed = 130;
    
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
