using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    public float speed;

    private void Start()
    {
        
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("Camera Constraint").gameObject;

    }

    private void FixedUpdate()
    {
        follow();
    }

    private void follow()
    {
        // smoothly moves to the target with speed
        transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        transform.LookAt(Player.gameObject.transform.position);
    }
}
