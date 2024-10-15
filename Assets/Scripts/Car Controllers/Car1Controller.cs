using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car1Controller : CarController
{
    public float steeringMax = 0.6f;
    public float braking = 5.6f;
    public float acceleration = 6f;
    public float maxSpeed = 106;
    
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
