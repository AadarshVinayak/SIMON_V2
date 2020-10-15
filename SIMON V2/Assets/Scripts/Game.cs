using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{

    struct ColoredTile
    {
        public string color_name;
        public string color_hex;
    }

    [SerializeField] Theme theme;
    [SerializeField] WinCondition condition;
    [SerializeField] Player p;
    [SerializeField] Score score;


    [SerializeField] float duration;

    List<ColoredTile> colors = new List<ColoredTile>();
    Tile[] tiles;
    float timeBetweenRounds = 3f;

    bool toReDraw = false;
    bool start = true;

    private void Awake()
    {
        CreateColorArray();
        CreateTileArray();

    }

    void Start()
    {

    }

    void Update()
    {
        if (start)
        {
            PopulateGrid();
            ChangeWinCondition();
            start = false;
        }
        if (toReDraw) StartCoroutine(ReDrawGrid());
    }

    private IEnumerator ReDrawGrid()
    {
        toReDraw = false;
        yield return new WaitForSeconds(timeBetweenRounds);
        //
        /*comment this out to test game*/ //toReDraw = true;
        if (CheckWinCondition())
        {
            ChangeWinCondition();
            PopulateGrid();
            //toReDraw = true;
            UpdateScore();
            ChangeTime();
            p.ToMove(true);
        } else
        {
            FindObjectOfType<GameOver>().SetGameOver(true);
            p.ToMove(false);
            WhiteOutGrid();
        }
    }

    private void ChangeTime()
    {
        if (timeBetweenRounds >= 1.5f) timeBetweenRounds -= 0.1f;
    }

    public float GetTimeBetweenRounds()
    {
        return timeBetweenRounds/3f;
    }

    private void UpdateScore()
    {
        score.UpdateScore(score.GetScore() + 1);
    }

    private void CreateTileArray()
    {
        //finds all the tiles in the game and adds them to a array
        tiles = FindObjectsOfType<Tile>();
    }

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

        //Duplicate the amount of colors 4 times to match the number of tiles
        List<ColoredTile> temps = colors;
        for (int i =0; i<3; i++) colors.AddRange(temps);
    }

    private void PopulateGrid()
    {
        //Randomizes the list of colors and then updates a tiles name and color to match the theme
        RandomizeColors();
        for(int i =0; i< tiles.Length; i++)
        {
            tiles[i].ChangeColor(HexToColor(colors[i].color_hex), colors[i].color_name);
        }
        toReDraw = true;
    }

    private void WhiteOutGrid()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].ChangeColor(Color.white, "White");
        }
        condition.SetWinCondition("Loser", Color.white);
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

    private void ChangeWinCondition()
    {
        ColoredTile tile = PickRandomColor();
        condition.SetWinCondition(tile.color_name, HexToColor(tile.color_hex));
    }

    private bool CheckWinCondition()
    {
        if (condition.GetName().Equals(p.GetCurrentTile())) return true;
        return false;
    }

    private ColoredTile PickRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Count);
        return colors[randomIndex];
    }

    public static Color HexToColor(string hexString)
    {
        //helper function designed to get the color from the themes
        Color c;
        String toBeConverted = "#" + hexString;
        if (ColorUtility.TryParseHtmlString(toBeConverted, out c))
        {
            return c;
        }
        else
        {
            return Color.white;
        }
    }
}
