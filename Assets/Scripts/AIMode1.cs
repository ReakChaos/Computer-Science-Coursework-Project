using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMode1 : AICarController
{
    public float steeringMax = 0.8f;
    public float braking = 14f;
    public float acceleration = 6f;
    public float maxSpeed = 106;

    public WaypointContainer waypointContainer;
    public List<Transform> waypoints;
    public int currentWaypoint;
    public float waypointRange = 13;
    
    public float maximumAngle = 45.0f;

    // Start is called before the first frame update
    public void Start()
    {
        // gets the components for the input manager and the rigid body
        rigidbody = GetComponent<Rigidbody>();
        // clamping two values
        steeringAng = Mathf.Clamp(steeringAng, -90f, 90f);

        waypoints = waypointContainer.waypoints;
        currentWaypoint = 0;
    }

    private void FixedUpdate()
    {
        // if distance between car and waypoint smaller than range switch waypoint in front
        if (Vector3.Distance(waypoints[currentWaypoint].position, transform.position) < waypointRange)
        {
            currentWaypoint++;
            // if reached the end cycle back
            if (currentWaypoint == waypoints.Count) currentWaypoint = 0;
        }

        // forward direction of car
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // find angle between car and waypoint
        steeringAng = Vector3.SignedAngle(fwd, waypoints[currentWaypoint].position - transform.position, Vector3.up);

        // finds the interpolation between throttle and angle of turn, if turning dont speed up
        // only moves when not reversing
        if (!isReversing)
            throttle = Mathf.Clamp01((maximumAngle -
                                      Mathf.Abs(rigidbody.velocity.magnitude * 0.5f * steeringAng) / maximumAngle));
        // calculates the amount needed to brake depending on the speed
        if (isInsideBreaking && !isReversing)
        {
            throttle = -throttle * ((Mathf.Clamp01(rigidbody.velocity.magnitude / (120f / 3.6f)) * 2 - 1f));
        }

        Debug.DrawRay(transform.position, waypoints[currentWaypoint].position - transform.position, Color.yellow);

        addDownForce();
        animateWheels();
        // when reversing change wheel direction
        if (isReversing)
        {
            // as steeringAng is from -90 to 90 but what we need is -1 to 1
            steering(steeringMax, -(steeringAng / 90f));
        }
        else
        {
            steering(steeringMax, steeringAng / 90f);
        }
        moveVehicle(acceleration, braking);
        topSpeed(maxSpeed);

        if (rigidbody.velocity.magnitude < 0.5f)
        {
            reverseTimer += Time.deltaTime;
            if (reverseTimer > 1)
            {
                StartCoroutine(reversing());
                reverseTimer = 0;
            }
        }
        // after it reverses it should revert back to 0 seconds
        else
        {
            reverseTimer = 0;
        }
        
    }

    IEnumerator reversing()
    {
        // to prevent calls again to function
        if (!isReversing)
        {
            // set reversing to true so FixedUpdate() method doesn't collide
            isReversing = true;
            throttle = -1f;
            yield return new WaitForSeconds(1f);
            // if reversing does not work it is stuck facing forward
            if (rigidbody.velocity.magnitude < 0.5f)
            {
                throttle = 1f;
                yield return new WaitForSeconds(1f);
                isReversing = false;
            }
            yield return new WaitForSeconds(1f);
            isReversing = false;   
        }
    }
}
