using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;
    int scoreNum = 0;
    

    void Start()
    {
        score = gameObject.GetComponent<TMP_Text>();
        score.text = "0";
    }

    public void Update()
    {
        score.text = scoreNum.ToString();
    }

    //This score will recieve an update during the game loop
    public void UpdateScore(int newScore)
    {
        scoreNum = newScore;
    }

    public int GetScore()
    {
        return scoreNum;
    }

}
