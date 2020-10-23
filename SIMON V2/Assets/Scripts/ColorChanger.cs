using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class ColoredTile
{
    //Just to manage the theme
    public string color_name;
    public string color_hex;

    public void SetColor(string name, string hex)
    {
        color_name = name;
        color_hex = hex;
    }
}

public static class ColorChanger
{
    public static List<ColoredTile> CreateColorArray(Theme theme, int rows)
    { 
        //defines a temp list
        List<ColoredTile> temps = new List<ColoredTile>();

        //creates an object of that type and adds it to the list
        ColoredTile temp = new ColoredTile();
        temp.SetColor(theme.color1_name, theme.color1_color);
        temps.Add(temp);
        ColoredTile temp1 = new ColoredTile();
        temp1.SetColor(theme.color2_name, theme.color2_color);
        temps.Add(temp1);
        ColoredTile temp2 = new ColoredTile();
        temp2.SetColor(theme.color3_name, theme.color3_color);
        temps.Add(temp2);
        ColoredTile temp3 = new ColoredTile();
        temp3.SetColor(theme.color4_name, theme.color4_color);
        temps.Add(temp3);
        ColoredTile temp4 = new ColoredTile();
        temp4.SetColor(theme.color5_name, theme.color5_color);
        temps.Add(temp4);

        List<ColoredTile> colors = new List<ColoredTile>();
        //Duplicate the amount of colors #rows times to match the number of tiles
        for (int i = 0; i < rows; i++) colors.AddRange(temps);

        return colors;
    }

    public static void RandomizeColors(List<ColoredTile> colors)
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
        if (alpha > 0 && alpha < 1) c.a = alpha;
        return c;
    }

    public static Color HexToColor(string hexString)
    {
        //helper function designed to get the color from the themes
        Color c;
        string toBeConverted = "#" + hexString;
        if (ColorUtility.TryParseHtmlString(toBeConverted, out c))
        {
            c.a = 1f;
            return c;
        }
        else
        {
            return Color.white;
        }
    }
}
