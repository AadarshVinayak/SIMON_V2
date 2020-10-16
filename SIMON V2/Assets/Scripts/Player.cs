using System.Collections;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    //coordinates
    float x;
    float y;

    //This is the displacement between each tile
    float displacement = 1.125f;
    //number of rows
    float rows = 5;

    //flag to dtermine movement
    bool movement;

    //The current tile that the player is on
    GameObject current;

    //time to move to a different tile
    float duration = 0.1f;

    //Used for touch input
    Vector2 startTouchPosition, endTouchPosition;

    void Start()
    {
        movement = true;
        x = 0f;
        y = 0f;
    }


    //Touch screen input system
    private void CheckForInputTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (Math.Abs(endTouchPosition.x - startTouchPosition.x) > Math.Abs(endTouchPosition.y - startTouchPosition.y))
            {
                if ((endTouchPosition.x < startTouchPosition.x) && x > 0)
                {
                    x -= displacement;
                    MoveSlow();
                }
                if ((endTouchPosition.x > startTouchPosition.x) && x < displacement * (rows - 1))
                {
                    x += displacement;
                    MoveSlow();
                }
            }
            else
            {
                if ((endTouchPosition.y < startTouchPosition.y) && y > 0)
                {
                    y -= displacement;
                    MoveSlow();
                }
                if ((endTouchPosition.y > startTouchPosition.y) && y < displacement * (rows - 1))
                {
                    y += displacement;
                    MoveSlow();
                }
            }
        }
    }


    //computer testing input
    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //SlowlyMoveUp();
            if (y < displacement * (rows - 1))
            {
                y += displacement;
                MoveSlow();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (y > 0)
            {
                y -= displacement;
                MoveSlow();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (x > 0)
            {
                x -= displacement;
                MoveSlow();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (x < displacement * (rows - 1))
            {
                x += displacement;
                MoveSlow();
            }
        }
    }

    void Update()
    {
        if (movement)CheckForInput();
        if (movement) CheckForInputTouch();
    }

    //move with a lerp
    private void MoveSlow()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        Vector2 starting = transform.position;
        Vector2 end = new Vector2(x, y);
        float i = 0.0f;
        while (i < 1.0f)
        {
            i += Time.deltaTime / duration;
            gameObject.transform.position = Vector2.Lerp(starting,end,i);
            yield return null;
        }
    }

    public void SetCurrent(GameObject t)
    {
        current = t;
    }
    

    public string GetCurrentTile()
    {
        return current.name;
    }
    
    public void ToMove(bool toMove)
    {
        movement = toMove;
    }
}
