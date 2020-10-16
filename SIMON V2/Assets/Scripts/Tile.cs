using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //The main game and player game objects
    Game playSpace;
    Player p;

    //Lerp paramaters
    Color color;
    Color changedColor;

    //lerp duration between 0 and 1
    [SerializeField] [Range(0f, 1f)] float duration;

    private void Start()
    {
        p = FindObjectOfType<Player>();
        playSpace = FindObjectOfType<Game>();
    }

    private void ChangeColorViaGradient()
    {
        StartCoroutine(onHolding());
    }

    private IEnumerator onHolding() {
        float i = 0.0f;
        ChangeDuration();
        while (i< 1.0f)
        {
            i += Time.deltaTime/ duration;
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(color, changedColor, i);
            yield return null; 
        }
    }

    //Changes the speed of the tiles lerp
    private void ChangeDuration()
    {
        float timeDifference = playSpace.GetTimeBetweenRounds();
        duration = duration * timeDifference;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            p.SetCurrent(gameObject);
        }
        catch { }
    }

    //called by the game to change the color of the tiles
    public void ChangeColor(Color c, string name)
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        changedColor = c;
        gameObject.name = name;
        ChangeColorViaGradient();
    }
}
 