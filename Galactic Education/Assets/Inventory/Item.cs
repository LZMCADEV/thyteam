using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    // Start is called before the first frame update
    public enum ItemType {
        HealthPotion,
        StaminaPotion,
        Sword,
        
        
    }

    public ItemType itemType; 
    public int amount;

    public Sprite GetSprite(){
        switch (itemType){
            default:
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.StaminaPotion: return ItemAssets.Instance.staminaPotionSprite;
        }
    }

    public Color GetColor(){
        switch (itemType){
            default:
            case ItemType.Sword: return new Color (0, 1, 0);
            case ItemType.HealthPotion: return new Color (1, 0, 0);
            case ItemType.StaminaPotion: return new Color (0, 0, 1);
            
        }
    }

    public bool IsStackable() {
        switch (itemType){
            default:
            case ItemType.Sword:
                return false;  
            case ItemType.HealthPotion:
            case ItemType.StaminaPotion:
            
                return true;
            
            
        }
    }

}
