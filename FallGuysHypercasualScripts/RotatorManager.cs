using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorManager : MonoBehaviour
{
    //private float speed = 2f;
    private Rigidbody rb;
[Range(0f,15f)][SerializeField] private float speed;

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
        rb.AddTorque(Vector3.up * speed, ForceMode.Acceleration);
        rb.maxAngularVelocity = 1.25f;

    }
}
