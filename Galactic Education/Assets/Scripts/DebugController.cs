using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    bool showConsole;
    string input;

    public void OnToggleDebug(){
        showConsole = !showConsole;
        Debug.Log (showConsole);
    }

    

    
}
