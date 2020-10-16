using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{   

    [SerializeField] Theme theme;

    //list of colors
    List<ColoredTile> colors = new List<ColoredTile>();

    //lerp requirements
    Color color;
    Color changedColor;
    float duration = 2.0f;

    //loop the lerp
    bool flag = true;

  
    private void Start()
    {
        colors = ColorChanger.CreateColorArray(theme, 1);
        ColorChanger.RandomizeColors(colors);
        gameObject.GetComponent<Image>().color = ColorChanger.HexToColor(colors[0].color_hex);
    }

    private void Update()
    {
        if (flag) ChangeColorViaGradient();
    }
    
    //Change the color via lerp
    private void ChangeColorViaGradient()
    {
        flag = false;
        ColorChanger.RandomizeColors(colors);
        color = gameObject.GetComponent<Image>().color;
        changedColor = ColorChanger.HexToColor(colors[0].color_hex);
        StartCoroutine(onHolding());
    }

    private IEnumerator onHolding()
    {
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime / duration;
            gameObject.GetComponent<Image>().color = Color.Lerp(color, changedColor, i);
            yield return null;
        }
        flag = true;
    }
}
