using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Spirit_Score : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI spiritScore;
    public int changeCounter = 0;
    public Variable_Int SpiritPoints;

    public void setSpiritScore(int amount){
        SpiritPoints = ES3.Load<Variable_Int>("save_SpiritPoints");
        if (SpiritPoints.value > 999){
            changeCounter = 999;
            SpiritPoints.value = 999;
            
        } 
        else if (SpiritPoints.value < 0){
            changeCounter = 0;
            SpiritPoints.value = 0;
        }
        else {
            changeCounter = amount;
            SpiritPoints.value = amount;
        }

        if (SpiritPoints.value < 0){
            spiritScore.text = "000";
        }
        else if (SpiritPoints.value.ToString().Length == 1){
            spiritScore.text = "00" + SpiritPoints.value.ToString();
        } 
        else if(SpiritPoints.value.ToString().Length == 2) {
            spiritScore.text = "0" + SpiritPoints.value.ToString();
        }
        else if (SpiritPoints.value < 1000){
            spiritScore.text = SpiritPoints.value.ToString();
        }
        
        else {
            spiritScore.text = "999";
        }
        ES3.Save("save_SpiritPoints", SpiritPoints);
    }

    void Start()
    {

        if(ES3.KeyExists("save_SpiritPoints")) {  
            SpiritPoints = ES3.Load<Variable_Int>("save_SpiritPoints");
            changeCounter = ES3.Load<Variable_Int>("save_SpiritPoints").value;
            
        } else {
            ES3.Save("save_SpiritPoints", SpiritPoints);
        }
        
    }

    // Update is called once per frame
    void Update()
    {


            
    }
}
