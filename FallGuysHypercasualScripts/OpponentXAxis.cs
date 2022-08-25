using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentXAxis : MonoBehaviour
{
    public GameObject OpponentCharacter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Donut"))
        {
            OpponentCharacter.GetComponent<OpponentMovement>().SetRandomXAxis(12f, 19f);
            print("donutTrigger");
        }
        if (other.gameObject.CompareTag("StaticObstacle"))
        {
            
            OpponentCharacter.GetComponent<OpponentMovement>().SetRandomXAxis(-18f, 7f);
            print("StaticTrigger");
        }
        
    }
    private void Update()
    {
        transform.position = OpponentCharacter.transform.position + new Vector3(0, 2.82f, 15f);
    }
}

