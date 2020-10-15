using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;

    public GameObject pauseMenuUI;
    public GameObject mainGame;


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        mainGame.SetActive(false);
        pauseMenuUI.SetActive(true);
        gameOver = false;
    }

    public void SetGameOver(bool x)
    {
        gameOver = x;
    }
}
