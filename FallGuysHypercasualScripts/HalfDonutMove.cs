using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutMove : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform startPos;
    [SerializeField] private float donutSpeed;
    private float timer;
    private bool controller;

    private void Awake()
    {
        
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 2f;
        controller = true;
       
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        MoveForward();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Forward"))
        {
            controller = true;
        }
        if (other.CompareTag("Backward"))
        {
            controller = false;
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.right*5f,ForceMode.Impulse);
            print("power");
        }
    }
    private void MoveForward()
    {
        if (controller)
        {
            rb.AddForceAtPosition(Vector3.right * donutSpeed, targetPos.position, ForceMode.Impulse);
            
        }
        else
        {
            rb.AddForceAtPosition(Vector3.right * -donutSpeed, startPos.position, ForceMode.Impulse);
            
        }
    }
    private void MoveBackWard()
    {

    }


}
