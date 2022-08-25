using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private float timer;
    public GameObject restartButton;

    private void Update()
    {
        timer += Time.deltaTime;
        GameOver(timer);
    }
    private void GameOver(float timer)
    {
        if (timer >= 30f)
        {
            if(restartButton!=null)
            restartButton.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
        GameManager.state = GameManager.GameStates.WaitingForFirstTouch;
    }
}
