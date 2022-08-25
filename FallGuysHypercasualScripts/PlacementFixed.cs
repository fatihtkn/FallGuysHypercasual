using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementFixed : MonoBehaviour
{
    public float placementNumber;
    
    
    private void Start()
    {
        placementNumber = 104f;
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        placementNumber-=8 ;
        other.transform.position += new Vector3(0, 0, placementNumber);
        DisableOpponentCamera(other);

    }
    private void DisableOpponentCamera(Collider other)
    {
        if (other.gameObject.GetComponentInParent<OpponentCamera>()!=null)
        {
            other.gameObject.GetComponentInParent<OpponentCamera>().enabled = false;
            
        }
        
    }
    
}
