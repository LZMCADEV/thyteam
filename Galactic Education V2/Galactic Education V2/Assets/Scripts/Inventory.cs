using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using QFSW.QC.Actions;

public class Inventory 
{
    // Start is called before the first frame update
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private Action<Item> useItemAction;
    private int itemDisplacement = 0;

    public void Start(){
        
    }

    public Inventory(Action<Item> useItemAction) {
        this.useItemAction = useItemAction;

        if(ES3.KeyExists("save_itemList")) {  
            itemList = ES3.Load<List<Item>>("save_itemList");
            OnItemListChanged?.Invoke(itemList, EventArgs.Empty);
            
        } else {
            itemList = new List<Item>();

            AddItem(new Item{itemType = Item.ItemType.Sword, amount=1});
            AddItem(new Item{itemType = Item.ItemType.HealthPotion, amount=1});
            AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
            ES3.Save("save_itemList", GetItemlist());
        }
        

        

    }



    

    public void AddItem(Item item){
        if (item.IsStackable()){ 
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList){
                if (inventoryItem.itemType == item.itemType && (inventoryItem.amount + item.amount) <= item.MaxAmount()) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                    

                    
                } else if ( inventoryItem.itemType == item.itemType && (inventoryItem.amount + item.amount) >= item.MaxAmount()) {
                    itemDisplacement = 0;
                    do {

                        itemDisplacement += 1;
                        item.amount -= 1;

                    } while ((inventoryItem.amount + item.amount) >= item.MaxAmount());


                    inventoryItem.amount += item.amount;
                    item.amount = itemDisplacement;
                    itemList.Add(item);
                    itemAlreadyInInventory = true;
                    OnItemListChanged?.Invoke(this, EventArgs.Empty);
                    break;
                    
                    
                }
            }
            if (!itemAlreadyInInventory){
                
                itemList.Add(item);
            }

            
        } else {
            itemList.Add(item);
        }
        
        ES3.Save("save_itemList", GetItemlist());
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void RemoveItem(Item item) {
        if (item.IsStackable()){ 
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList){
                if (inventoryItem.itemType == item.itemType && inventoryItem.amount == item.amount) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                    
                }
                
            }
            if (itemInInventory != null && itemInInventory.amount <=0 ){
                
                itemList.Remove(itemInInventory);
            }

            
        } else {
            itemList.Remove(item);
        }
        ES3.Save("save_itemList", itemList);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item){

        useItemAction(item);

    }
    public List<Item> GetItemlist(){
        return itemList;
    }




}
