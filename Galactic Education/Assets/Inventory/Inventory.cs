using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    // Start is called before the first frame update
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        AddItem(new Item{itemType = Item.ItemType.Sword, amount=1});
        AddItem(new Item{itemType = Item.ItemType.HealthPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.Sword, amount=1});
        AddItem(new Item{itemType = Item.ItemType.HealthPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.Sword, amount=1});
        AddItem(new Item{itemType = Item.ItemType.HealthPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});
        AddItem(new Item{itemType = Item.ItemType.StaminaPotion, amount=1});

        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item){
        itemList.Add(item);
    }

    public List<Item> GetItemlist(){
        return itemList;
    }




}
