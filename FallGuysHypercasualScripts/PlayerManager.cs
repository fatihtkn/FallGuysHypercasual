using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public TMP_Text text;
    private float sayac;
    [SerializeField] private GameObject wallPaintObj;
    [SerializeField] private Transform restartPos;
    [SerializeField] private GameObject progressBar;
    public GameObject vfx;
    public Transform playerPos;
    private CameraManager camManager;
    private void Start()
    {
        
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
    }
    private void Update()
    {
        
        sayac += Time.deltaTime;
        text.text = sayac.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Death();
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                PlayerMovement.targetClampValue = 14f;
            }
            else
            {
                PlayerMovement.targetClampValue = 19.5f;
            }

            
        }
        if (other.gameObject.CompareTag("StaticObstacle"))
        {
            Death();
            PlayerMovement.targetClampValue = 19.5f;
        }
        if (other.gameObject.CompareTag("Range30"))
        {   
            PlayerMovement.targetClampValue = 30f;
        }
        if (other.gameObject.CompareTag("Range14"))
        {
            PlayerMovement.targetClampValue = 14f;
            
        }
        if (other.gameObject.CompareTag("Range19"))
        {
            PlayerMovement.targetClampValue = 19.5f;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.state = GameManager.GameStates.WallPainting;
            progressBar.SetActive(true);
        }
        if (other.gameObject.CompareTag("Level2Finish"))
        {
            //GameManager.state = GameManager.GameStates.GameOver;
            GetComponent<Animator>().SetTrigger("Victory");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            camManager.vCameras[0].enabled = false;
        }
        
    }
    private void Death()
    {
        Instantiate(vfx, playerPos.position+new Vector3(0,5,0), Quaternion.identity);
        
        transform.position = restartPos.position;
        
    }
   
}
