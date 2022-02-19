using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryButton : MonoBehaviour
{

    private Transform inventoryPanel;
    CanvasGroup canvasGroup;

    private bool isGamePaused;

    public void Awake (){
        inventoryPanel = transform.Find("Panel");
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }




    public void inventoryButton(){

        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup.alpha == 1f){
            Time.timeScale = 1f;
            isGamePaused = false;
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        } else {
            if (!isGamePaused) {
                Time.timeScale = 0f;
                isGamePaused = true;
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            
        }
    }
}
