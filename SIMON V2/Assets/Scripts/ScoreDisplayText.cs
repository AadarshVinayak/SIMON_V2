using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayText : MonoBehaviour
{
    TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TMP_Text>();
        Score score = FindObjectOfType<Score>();
        if (score.IsScoreGreaterThenHS(score.GetScore()))
        {
            scoreText.text = "NEW HIGH SCORE!!";    
        } else
        {
            scoreText.text = "TRY AGAIN?";
        }
    }
}
