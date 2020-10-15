using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{   
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
        colors = ColorChanger.CreateColorArray(theme, 5);
        Debug.Log(colors.Count);
        CreateTileArray();

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

    private void UpdateScore()
    {
        score.UpdateScore(score.GetScore() + 1);
    }

    private void CreateTileArray()
    {
        //finds all the tiles in the game and adds them to a array
        tiles = FindObjectsOfType<Tile>();
    }

    private void PopulateGrid()
    {
        //Randomizes the list of colors and then updates a tiles name and color to match the theme
        ColorChanger.RandomizeColors(colors);
        for(int i =0; i< tiles.Length; i++)
        {
            tiles[i].ChangeColor(ColorChanger.HexToColor(colors[i].color_hex), colors[i].color_name);
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


    private void ChangeWinCondition()
    {
        ColoredTile tile = PickRandomColor();
        condition.SetWinCondition(tile.color_name, ColorChanger.HexToColor(tile.color_hex));
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

    public float GetTimeBetweenRounds()
    {
        return timeBetweenRounds / 3f;
    }


}
