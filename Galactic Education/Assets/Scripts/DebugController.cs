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

    

    private void OnGui(){
        if (showConsole){
            Debug.Log ("Hi");
            float y = 0f;
            GUI.Box(new Rect(0, y, Screen.width, 30), "");
            GUI.backgroundColor = new Color (0, 0, 0, 0);
            input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
        }

        


    }

}
