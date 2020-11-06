using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    Animation shop;
    Animation settings;
    Animation main;


    (string state, Animation ani) currentState;
    string newState;

    private void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<Animation>();
        settings = GameObject.FindGameObjectWithTag("Settings").GetComponent<Animation>();
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Animation>();
        currentState = ("Main", main);
        newState = "Main";
    }

    public void SetState(string s)
    {
        Debug.Log("Worked: " + s);
        newState = s;
    }

    public void Update()
    {
        if(currentState.state != newState)
        {
            switch (newState)
            {
                case "Main":
                    Debug.Log("Main: " + currentState.ToString());
                    main.Play("UIEnterLeft");
                    currentState.ani.Play("UILeaveRight");
                    currentState = (newState, main);
                    break;
                case "Shop":
                    Debug.Log("Shop: " + currentState.ToString());
                    shop.Play("UIEnter");
                    currentState.ani.Play("UILeave");
                    currentState = (newState, shop);
                    break;
                case "Settings":
                    Debug.Log("Settings: " + currentState.ToString());
                    settings.Play("UIEnter");
                    currentState.ani.Play("UILeave");
                    currentState = (newState, settings);
                    break;
            }
        }
    }
}
