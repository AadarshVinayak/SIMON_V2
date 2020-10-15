using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Game playSpace;
    Player p;
    Color color;
    Color changedColor;

    float t;

    [SerializeField] [Range(0f, 1f)] float duration;

    bool toChange = false;

    private void Start()
    {
        p = FindObjectOfType<Player>();
        playSpace = FindObjectOfType<Game>();
    }

    private void Update()
    {
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
        toChange = false;
    }


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

    public void ChangeColor(Color c, string name)
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        changedColor = c;
        gameObject.name = name;
        ChangeColorViaGradient();
    }
}
 