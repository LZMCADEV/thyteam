using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


}
