using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PlacementManager : MonoBehaviour
{
    public GameObject Player;
    public float[] opponent_pos;
    public GameObject[] AI;
    private float playerPos;
    public TMP_Text[] text;
    private void Update()
    {
        CalculatePos();
    }
    private void CalculatePos()
    {
        opponent_pos[0] = Player.GetComponent<PlayerMovement>().playerDistance;
        opponent_pos[1] = AI[0].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[2] = AI[1].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[3] = AI[2].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[4] = AI[3].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[5] = AI[4].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[6] = AI[5].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[7] = AI[6].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[8] = AI[7].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[9] = AI[8].GetComponent<OpponentMovement>().opponentDistance;
        opponent_pos[10] = AI[9].GetComponent<OpponentMovement>().opponentDistance;

        playerPos= Player.GetComponent<PlayerMovement>().playerDistance;
        Array.Sort(opponent_pos);
        int playerPlacement = Array.IndexOf(opponent_pos, playerPos);
        int AI1Pos= Array.IndexOf(opponent_pos, AI[0].GetComponent<OpponentMovement>().opponentDistance);
        int AI2Pos = Array.IndexOf(opponent_pos, AI[1].GetComponent<OpponentMovement>().opponentDistance);
        int AI3Pos = Array.IndexOf(opponent_pos, AI[2].GetComponent<OpponentMovement>().opponentDistance);
        int AI4Pos = Array.IndexOf(opponent_pos, AI[3].GetComponent<OpponentMovement>().opponentDistance);
        int AI5Pos = Array.IndexOf(opponent_pos, AI[4].GetComponent<OpponentMovement>().opponentDistance);
        int AI6Pos = Array.IndexOf(opponent_pos, AI[5].GetComponent<OpponentMovement>().opponentDistance);
        int AI7Pos = Array.IndexOf(opponent_pos, AI[6].GetComponent<OpponentMovement>().opponentDistance);
        int AI8Pos = Array.IndexOf(opponent_pos, AI[7].GetComponent<OpponentMovement>().opponentDistance);
        int AI9Pos = Array.IndexOf(opponent_pos, AI[8].GetComponent<OpponentMovement>().opponentDistance);
        int AI10Pos = Array.IndexOf(opponent_pos, AI[9].GetComponent<OpponentMovement>().opponentDistance);


        text[0].text = (playerPlacement + 1).ToString();
        text[1].text = (AI1Pos + 1).ToString();
        text[2].text = (AI2Pos + 1).ToString();
        text[3].text = (AI3Pos + 1).ToString();
        text[4].text = (AI4Pos + 1).ToString();
        text[5].text = (AI5Pos + 1).ToString();
        text[6].text = (AI6Pos + 1).ToString();
        text[7].text = (AI7Pos + 1).ToString();
        text[8].text = (AI8Pos + 1).ToString();
        text[9].text = (AI9Pos + 1).ToString();
        text[10].text = (AI10Pos + 1).ToString();





    }

}
