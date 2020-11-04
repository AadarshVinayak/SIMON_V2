using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsToAdd : MonoBehaviour
{
    int pointsInt = 0;
    Points points;
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
        text = gameObject.GetComponent<TMP_Text>();
        pointsInt = points.GetPointsToAdd();
        text.text = pointsInt.ToString();
    }

    public void AddPoints()
    {
        FindObjectOfType<PointsDisplay>().ChangePoints(points.AddPoints(pointsInt));
    }
}
