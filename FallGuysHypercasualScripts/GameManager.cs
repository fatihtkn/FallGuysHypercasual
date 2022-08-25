using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameStates state;
    

    private void Start()
    {
        
        

    }

   


    public enum GameStates
    {
        WaitingForFirstTouch,
        Started,
        WallPainting,
        GameOver

    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");

    }
}
