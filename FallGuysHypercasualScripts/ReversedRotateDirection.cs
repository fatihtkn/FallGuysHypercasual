using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversedRotateDirection : MonoBehaviour
{
    //private float speed = 2f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        //transform.Rotate(0, 90 * Time.deltaTime, 0);


    }
    private void FixedUpdate()
    {
        //rb.MoveRotation(Quaternion.Euler(0, 90*speed*Time.fixedDeltaTime+5, 0));
        rb.AddTorque(Vector3.forward* -1* 10f*Time.fixedDeltaTime, ForceMode.Acceleration);
        rb.maxAngularVelocity = 1.25f;

    }
}

