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

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
        //ItemWorld.SpawnItemWorld(new Vector3(0, 0), new Item {itemType = Item.ItemType.HealthPotion, amount = 1});
        //ItemWorld.SpawnItemWorld(new Vector3(0, 1), new Item {itemType = Item.ItemType.StaminaPotion, amount = 1});
        //ItemWorld.SpawnItemWorld(new Vector3(0, -1), new Item {itemType = Item.ItemType.Sword, amount = 1});
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null){
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();

        } 
    }

    void Update()
    {
        
    }
}
