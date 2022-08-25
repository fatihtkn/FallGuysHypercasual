using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovement : MonoBehaviour
{
    public Transform target;
    public Transform rayPos;
    public Transform balancePos;
    
    private float sightDistance;
    [HideInInspector]public float randomForwardSpeed;
    [HideInInspector] public float targetClampValue;
    private float xAxis;
    public float randomLerpSpeed;
    [HideInInspector]public float randomRangeXaxis;

    private Rigidbody rb;
    public bool running;
    public static OpponentMovement opponentMovement;
    public LayerMask mask;

    public Transform finishDistance;
    public float opponentDistance;

    private void Awake()
    {
        finishDistance = GameObject.FindGameObjectWithTag("FinishDistance").transform;
    }

    private void Start()
    {
        running = true;
        opponentMovement=GetComponent<OpponentMovement>();
        sightDistance = 15f;
        rb = GetComponent<Rigidbody>();
        randomRangeXaxis = Random.Range(-5f, 3f);
        randomLerpSpeed = Random.Range(2f, 3f);
        randomForwardSpeed = Random.Range(10f, 15f);
        targetClampValue = 19.5f;
    }
    private void Update()
    {
        opponentDistance = Vector3.Distance(transform.position, finishDistance.position);
        ObstacleController();

        xAxisMovement();

        
        
        SetClampValue();
        
        rb.maxAngularVelocity = 1f;
    }
    private void FixedUpdate()
    {
        
        Movement(xAxis);
        
    }

    private void Movement(float xAxis)
    {
        if (running&GameManager.state==GameManager.GameStates.Started&running)
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + Time.fixedDeltaTime*speed);

            rb.MovePosition(new Vector3(xAxis,transform.position.y,transform.position.z+Time.fixedDeltaTime*randomForwardSpeed));
        }
        
    }

    private bool  CalculateDistance()
    {
        bool isRunning = Vector3.Distance(transform.position, target.position) > 5f;
        return isRunning;
    }
    private void SetClampValue()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -targetClampValue, targetClampValue), transform.position.y, transform.position.z);
        
    }
    private void ObstacleController()
    {
        Debug.DrawLine(rayPos.position, rayPos.position + new Vector3(0, 0, sightDistance), Color.red);
        if(Physics.Raycast(rayPos.position, Vector3.forward, out RaycastHit hit, sightDistance))
        {
            //if (hit.collider.CompareTag("StaticObstacle"))
            //{
            //    //xAxis = Mathf.Lerp(transform.position.x, 2.20f, lerpSpeed * Time.deltaTime * 1.1f);

                
            //    print("çalýþýyor");
            //}
            //if (hit.collider.CompareTag("Donut"))
            //{
            //    //xAxis = Mathf.Lerp(transform.position.x, 2.20f, lerpSpeed * Time.deltaTime * 1.1f);

                
                
            //}
        }
        
    }
   

    private void xAxisMovement()
    {
        if (running)
        {
            if (Physics.CheckSphere(transform.position, 2f, mask))
            {
                randomRangeXaxis = balancePos.position.x;
                

                xAxis = Mathf.Lerp(transform.position.x, randomRangeXaxis, randomLerpSpeed * Time.deltaTime);

            }
            else
            {
                xAxis = Mathf.Lerp(transform.position.x, randomRangeXaxis, Time.deltaTime);
            }
        }
        

    }

   
   public void SetRandomXAxis(float min, float max)
    {
        randomRangeXaxis = Random.Range(min, max);
    }

   
}
