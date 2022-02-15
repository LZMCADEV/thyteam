using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public bool hasAlreadyEntered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                interactAction.Invoke();
            }
        }

        
    }
    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            if (!hasAlreadyEntered){
                isInRange = true;
                Debug.Log("Player is now in range");
                hasAlreadyEntered = true;
            }

            
        }
    }
    private void OnTriggerExit2D (Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            isInRange = false;
            Debug.Log("Player is not in range");
            hasAlreadyEntered = false;
        }

    }
}
