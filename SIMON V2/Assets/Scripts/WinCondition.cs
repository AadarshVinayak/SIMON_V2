using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    //Lerp parameters
    float duration = 0.2f;
    Color changedColor;

    //Given the name and color make the win condition
    public void SetWinCondition(string name, Color color)
    {
        changedColor = color;
        gameObject.name = name;
        ChangeColorViaGradient();
    }

    private void ChangeColorViaGradient()
    {
        StartCoroutine(SwapColor()) ;
    }

    private IEnumerator SwapColor()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime / duration;
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(color, changedColor, i);
            yield return null;
        }
    }

    //helper functions
    public string GetName()
    {
        return gameObject.name;
    }
}
