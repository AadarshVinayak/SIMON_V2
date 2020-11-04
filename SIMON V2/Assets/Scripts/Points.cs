using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    int newPoints;
    public int PointsCalculator(int score)
    {
        bool betterThenHS;
        Score s = FindObjectOfType<Score>();
        betterThenHS = s.IsScoreGreaterThenHS(score);
        int differenceInPoints = s.PointDifference(score);
        int points = 0;
        if (betterThenHS)
        {
            points += 10;
            if (Mathf.Abs(differenceInPoints) > 5) points += 5;
        }
        else
        {
            points += 5;
        }

        if (score > 20) points += 5;
        if (score > 30) points += 5;
        
        return points;
    }

    public int AddPoints(int points)
    {
        int newPoints = 0;
        newPoints  = points + GetPoints();
        SetPoints(newPoints);
        return newPoints;
    }



    public int GetPoints()
    {
        if (PlayerPrefs.HasKey("Points"))
        {
            return PlayerPrefs.GetInt("Points");
        } else
        {
            SetPoints(0);
            return 0;
        }
    }

    public void SetPoints(int points)
    {
        PlayerPrefs.SetInt("Points", points);
        PlayerPrefs.Save();
    }

    public void SetNewPoints(int points)
    {
        newPoints = points;
    }

    public int GetPointsToAdd()
    {
        return newPoints;
    }
}
