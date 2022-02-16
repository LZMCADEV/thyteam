using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;
    

    // Start is called before the first frame update
    private void Awake()
    {

        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);


        if(ES3.KeyExists("save_PlayerPos")) {  
            transform.position = ES3.Load<Vector3>("save_PlayerPos");
            
        } else {
            ES3.Save("save_PlayerPos", transform.position);
        }
    }
        
        //ItemWorld.SpawnItemWorld(new Vector3(0, 0), new Item {itemType = Item.ItemType.HealthPotion, amount = 1});
        //ItemWorld.SpawnItemWorld(new Vector3(0, 1), new Item {itemType = Item.ItemType.StaminaPotion, amount = 1});
        //ItemWorld.SpawnItemWorld(new Vector3(0, -1), new Item {itemType = Item.ItemType.Sword, amount = 1});
    

    // Update is called once per frame

    

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null){
            inventory.AddItem(itemWorld.GetItem());


            
            itemWorld.DestroySelf();

        } 
    }

    private void UseItem (Item item){
        switch (item.itemType){
            case Item.ItemType.HealthPotion:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1});
                break;
            case Item.ItemType.StaminaPotion:
                inventory.RemoveItem(new Item { itemType = Item.ItemType.StaminaPotion, amount = 1});
                break;

        }
    }

    public void Update(){
        ES3.Save("save_PlayerPos", transform.position);
    }
    
}
