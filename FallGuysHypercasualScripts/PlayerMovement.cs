using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Transform player;
    private Vector3 startMousePos, startPlayerPos;
    private bool moveTheplayer;
    public float maxSpeed;

    [SerializeField][Range(0f,1f)] private float forwardSpeed;
    
    private Rigidbody rb;
    private Vector3 referencePos;
    
    
    public static float targetClampValue;
    public float playerDistance;
    public Transform FinishDistance;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            targetClampValue = 14f;
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            targetClampValue = 19.5f;
        }
    }
    private void Start()
    {
        player = transform;
        maxSpeed = 0f;
        rb = GetComponent<Rigidbody>();
        
        

    }
    private void Update()
    {
        if (FinishDistance != null)
        {
            playerDistance = Vector3.Distance(transform.position, FinishDistance.position);
        }
        
        rb.maxAngularVelocity = 1f;
        if (GameManager.state == GameManager.GameStates.Started)
        {
            //player.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
            MovePlayer();
            
        }
        player.position = new Vector3(Mathf.Clamp(player.position.x, -targetClampValue, targetClampValue), player.position.y, player.position.z);
    }
    private void LateUpdate()
    {
        

    }
    private void FixedUpdate()
    {
        if (GameManager.state == GameManager.GameStates.Started)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Mathf.Clamp(rb.velocity.z, 0f, 14f));
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + Time.fixedDeltaTime * 30f*forwardSpeed);
            //rb.MovePosition(new Vector3(referencePos.x*Time.fixedDeltaTime*swerveSpeed, transform.position.y, transform.position.z + Time.fixedDeltaTime *forwardSpeed ));
        }


    }


    private void MovePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveTheplayer = true;
            Plane newPlan = new Plane(Vector3.up,0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(newPlan.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startPlayerPos = player.position;

            }


        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveTheplayer = false;
            
            rb.velocity = new Vector3(1,rb.velocity.y,rb.velocity.z);
            referencePos.x = 0;
            

        }
        if (moveTheplayer)
        {
            
            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 swipeDelta = mouseNewPos - startMousePos;
                Vector3 desiredPos = swipeDelta + startPlayerPos;
                referencePos = desiredPos;
                referencePos = new Vector3(Mathf.Clamp(referencePos.x, -30, 30), referencePos.y, referencePos.z);

                //referencePos=player.position = new Vector3(Mathf.SmoothDamp(player.position.x, desiredPos.x, ref velocity, maxSpeed), player.position.y, player.position.z);

                // rb.velocity = new Vector3(Mathf.SmoothDamp(rb.velocity.x, desiredPos.x, ref velocity, maxSpeed/2), rb.velocity.y, rb.velocity.z);

                rb.velocity = new Vector3(referencePos.x * Time.fixedDeltaTime * 90, rb.velocity.y, rb.velocity.z);
                
            }
        }

    }

    
    

}
