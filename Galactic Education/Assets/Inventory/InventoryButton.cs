using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{

    private Transform inventoryPanel;
    CanvasGroup canvasGroup;
    public Variable_Bool isGamePaused;

    public void Awake (){
        inventoryPanel = transform.Find("Panel");
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            canvasGroup = GetComponent<CanvasGroup>();
            Debug.Log(canvasGroup.alpha);
            if (canvasGroup.alpha == 1f){
                Time.timeScale = 1f;
                isGamePaused.value = false;
                canvasGroup.alpha = 0f;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            } else {
                if (!isGamePaused.value) {
                    Time.timeScale = 0f;
                    isGamePaused.value = true;
                    canvasGroup.alpha = 1f;
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                }
                
            }
        }
    }
}
