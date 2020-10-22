using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    public void PointsCalculator()
    {

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
}
