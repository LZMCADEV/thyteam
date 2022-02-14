using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    // Start is called before the first frame update
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        AddItem(new Item{itemType = Item.ItemType.Sword, amount=1});
        AddItem(new Item{itemType = Item.ItemType.HealthPotion, amount=2});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});


        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item){
        Debug.Log(item.itemType);
        if (item.IsStackable()){ 
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList){
                if (inventoryItem.itemType == item.itemType) {
                    Debug.Log(inventoryItem.amount.ToString() + inventoryItem.itemType.ToString());
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory){
                
                itemList.Add(item);
            }

            
        } else {
            itemList.Add(item);
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void RemoveItem(Item item) {
        if (item.IsStackable()){ 
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList){
                if (inventoryItem.itemType == item.itemType) {
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
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemlist(){
        return itemList;
    }




}
