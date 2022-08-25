using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
    [SerializeField] private Transform restartPos;
    private OpponentMovement opponenMovementScript;
    public GameObject vfx;
    private void Start()
    {
        opponenMovementScript = GetComponent<OpponentMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Death();
            opponenMovementScript.targetClampValue = 19.5f;
            opponenMovementScript.randomLerpSpeed = Random.Range(2f, 3f);
        }
        if (other.gameObject.CompareTag("Range30"))
        {
            opponenMovementScript.targetClampValue = 30f;
        }
        if (other.gameObject.CompareTag("Range19"))
        {
            opponenMovementScript.targetClampValue = 19.5f;
        }
        
        if (other.gameObject.CompareTag("StaticObstacle"))
        {
            transform.position = restartPos.position;
            opponenMovementScript.targetClampValue = 19.5f;
        }
        if (other.gameObject.CompareTag("Level2Finish"))
        {
            opponenMovementScript.SetRandomXAxis(0, 5f);
            opponenMovementScript.randomForwardSpeed = 0f;
            GetComponent<Animator>().SetTrigger("swing");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            



        }
    }
    private void Death()
    {
        Instantiate(vfx, transform.position, Quaternion.identity);
        transform.position = restartPos.position;
        
    }
}
