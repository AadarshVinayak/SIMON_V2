using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{   
    [Header("Main Components")]
    [SerializeField] Theme theme;
    [SerializeField] WinCondition condition;
    [SerializeField] Player p;
    [SerializeField] Score score;

    [Header("Timeing for transition")]
    [SerializeField] float duration;

    //Lists for the grid system
    List<ColoredTile> colors = new List<ColoredTile>();
    Tile[] tiles;
    
    //This is the longest time between rounds
    float timeBetweenRounds = 3f;

    //Flags to monitor when commands are operated
    bool toReDraw = false;
    bool start = true;

    //Initialize the game
    private void Awake()
    {
        //Initializing the grid
        colors = ColorChanger.CreateColorArray(theme, 5);
        CreateTileArray();
    }

    void Update()
    {
        //replaces the start fuinction because these dont operate correctly in it
        if (start)
        {
            PopulateGrid();
            ChangeWinCondition();
            start = false;
        }

        //The main game loop
        if (toReDraw) StartCoroutine(ReDrawGrid());
    }

    private IEnumerator ReDrawGrid()
    {
        //Turns off the gameloop until its all gone through once
        toReDraw = false;
        yield return new WaitForSeconds(timeBetweenRounds);
        //condition to continue playing
        if (CheckWinCondition())
        {
            //Condition is changed and the grid is updates with a score increase
            ChangeWinCondition();
            PopulateGrid();
            UpdateScore();
            ChangeTime();
            p.ToMove(true);
        } 
        else
        {
            //Bring up the gameover screen
            score.CheckHighScore(score.GetScore());
            Debug.Log(score.GetHighScore());
            FindObjectOfType<GameOver>().SetGameOver(true);
            p.ToMove(false);
            WhiteOutGrid();
        }
    }


    private void PopulateGrid()
    {
        //Randomizes the list of colors and then updates a tiles name and color to match the theme
        ColorChanger.RandomizeColors(colors);
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].ChangeColor(ColorChanger.HexToColor(colors[i].color_hex), colors[i].color_name);
        }
        toReDraw = true;
    }

    private void ChangeTime()
    {
        //changes the speed of the animations of the tiles changing colors
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

    private ColoredTile PickRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Count);
        return colors[randomIndex];
    }

    private void WhiteOutGrid()
    {
        //chagnes all the colors of the grid to white
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].ChangeColor(Color.white, "White");
        }
        condition.SetWinCondition("Loser", Color.white);
    }


    private void ChangeWinCondition()
    {
        //takes a random color and changes the condition to win
        ColoredTile tile = PickRandomColor();
        condition.SetWinCondition(tile.color_name, ColorChanger.HexToColor(tile.color_hex));
    }

    private bool CheckWinCondition()
    {
        //Is the last tile your player on, the same as the win condition
        if (condition.GetName().Equals(p.GetCurrentTile())) return true;
        return false;
    }

    public float GetTimeBetweenRounds()
    {
        //the percentage difference between the current speed and the original
        return timeBetweenRounds / 3f;
    }


}
