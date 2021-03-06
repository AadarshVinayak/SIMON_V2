using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;
    int scoreNum = 0;
    int oldHighScore = 0;
    

    void Start()
    {
        oldHighScore = GetHighScore();
        //ResetScore();
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

    public bool IsScoreGreaterThenHS(int newScore)
    {
        return (newScore > oldHighScore);
    }

    public int PointDifference(int newScore)
    {
        return (newScore - GetHighScore());
    }

    public void CheckHighScore(int newScore)
    {
        if (newScore > GetHighScore())
        {
            SetHighScore(newScore);
        }
    }

    private void SetHighScore(int newScore)
    {
        PlayerPrefs.SetInt("HighScore", newScore);
        PlayerPrefs.Save();
    }

    private void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            return PlayerPrefs.GetInt("HighScore");
        }
        return 0;
    }

}
