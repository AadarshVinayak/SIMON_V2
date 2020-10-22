using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{

    struct ColoredTile
    {
        public string color_name;
        public string color_hex;
    }


    [SerializeField] Theme theme;

    List<ColoredTile> colors = new List<ColoredTile>();

    Color color;
    Color changedColor;
    float duration = 2.0f;

    bool flag = true;

    private void CreateColorArray()
    {

        //Add all the values from the theme to the list
        ColoredTile temp;
        temp.color_name = theme.color1_name;
        temp.color_hex = theme.color1_color;
        colors.Add(temp);
        temp.color_name = theme.color2_name;
        temp.color_hex = theme.color2_color;
        colors.Add(temp);
        temp.color_name = theme.color3_name;
        temp.color_hex = theme.color3_color;
        colors.Add(temp);
        temp.color_name = theme.color4_name;
        temp.color_hex = theme.color4_color;
        colors.Add(temp);
        temp.color_name = theme.color5_name;
        temp.color_hex = theme.color5_color;
        colors.Add(temp);
    }


    private void RandomizeColors()
    {

        //Shuffles the list of colors
        for (int i = 0; i < colors.Count; i++)
        {
            ColoredTile temp = colors[i];
            int randomIndex = Random.Range(i, colors.Count);
            colors[i] = colors[randomIndex];
            colors[randomIndex] = temp;
        }
    }



    public static Color SetAlpha(Color c, float alpha)
    {
        if(alpha >0 && alpha < 1) c.a = alpha;
        return c;
    }


    public static Color HexToColor(string hexString)
    {
        //helper function designed to get the color from the themes
        Color c;
        String toBeConverted = "#" + hexString;
        if (ColorUtility.TryParseHtmlString(toBeConverted, out c))
        {
            c.a = 1.00f;
            return c;
        }
        else
        {
            return Color.white;
        }
    }

    private void Start()
    {
        CreateColorArray();
        RandomizeColors();
        gameObject.GetComponent<Image>().color = HexToColor(colors[0].color_hex);
    }

    private void Update()
    {
        if (flag) ChangeColorViaGradient();
    }




    private void ChangeColorViaGradient()
    {
        flag = false;
        RandomizeColors();
        color = gameObject.GetComponent<Image>().color;
        changedColor = HexToColor(colors[0].color_hex);
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
