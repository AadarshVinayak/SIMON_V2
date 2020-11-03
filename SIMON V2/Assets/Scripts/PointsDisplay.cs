using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    int newPoints;
    Points points;
    TMP_Text pointsText; 
    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
        pointsText = gameObject.GetComponent<TMP_Text>();
        pointsText.text = points.GetPoints().ToString();
    }

    public void SetScore()
    {

    }

    public void ChangePoints()
    {

    }
}
