using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsDisplay : MonoBehaviour
{
    Points points;
    TMP_Text pointsText; 
    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<Points>();
        pointsText = gameObject.GetComponent<TMP_Text>();
        pointsText.text = points.GetPoints().ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
