using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text score;
    int scoreNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = gameObject.GetComponent<TMP_Text>();
        score.text = "0";
    }

    public void Update()
    {
        score.text = scoreNum.ToString();
    }

    public void UpdateScore(int newScore)
    {
        scoreNum = newScore;
    }

    public int GetScore()
    {
        return scoreNum;
    }

    public int GetHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            return PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            SetHighScore(0);
            return 0;
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }

}
