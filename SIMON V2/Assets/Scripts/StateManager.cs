using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    string currentState;

    private void Start()
    {

        currentState = "Main";
    }

    public void SetState(string s)
    {
        currentState = s;
    }
}
