using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float f = 6f / Screen.currentResolution.width;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(f, f, 0);
    }
}
