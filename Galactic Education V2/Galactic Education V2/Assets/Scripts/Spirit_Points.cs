using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spirit_Points : MonoBehaviour
{
    public static Spirit_Points instance;
    public static int SpiritPoints = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpiritPoints > 999){
            SpiritPoints = 999;
        }
    }
}
