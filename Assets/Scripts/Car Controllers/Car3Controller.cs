using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car3Controller : CarController
{
    public float steeringMax = 0.55f;
    public float braking = 6f;
    public float acceleration = 6.8f;
    public float maxSpeed = 164;
    
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
