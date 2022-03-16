using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC.Actions;
using QFSW.QC;

[CommandPrefix("Player.")]
public class Player : MonoBehaviour
{

    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;
    private List<Item> itemList;
    
    public Spirit_Score sp;

    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar healthBar;

    

    [Command("damagePlayer")]
    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    

    [Command("spiritScore")]
    public void setSpiritScore(int amount){

        

        sp.setSpiritScore(amount);
        
        
    }

    [Command("add_health_potion")]
    public void addHealthPotion(int amount){
        
        itemList = ES3.Load<List<Item>>("save_itemList");
        inventory.AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = amount});
        ES3.Save("save_itemList", inventory.GetItemlist());
        
    }

    [Command("add_stamina_potion")]
    public void addStaminaPotion(int amount){
        itemList = ES3.Load<List<Item>>("save_itemList");
        inventory.AddItem(new Item { itemType = Item.ItemType.StaminaPotion, amount = amount});
        ES3.Save("save_itemList", inventory.GetItemlist());
        
    }


    // Start is called before the first frame update
    private void Awake()
    {

        
        currentHealth = maxHealth;

        if(ES3.KeyExists("save_PlayerPos")) {  
            transform.position = ES3.Load<Vector3>("save_PlayerPos");
            
        } else {
            ES3.Save("save_PlayerPos", transform.position);
        }
    }

    private void Start(){
        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);
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

        if (Input.GetKeyDown(KeyCode.H)){
            TakeDamage(10);
        }
    }
    
}
