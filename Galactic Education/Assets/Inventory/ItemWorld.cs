using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{



    
    private Item item;

    private SpriteRenderer spriteRenderer;

    public Light2D light2D;

    private TextMeshPro textMeshPro;
    
    

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();

        


    }

    

    public static ItemWorld DropItem(Vector3 dropPosition, Item item){



        Vector3 randomDir = UtilsClass.GetRandomDir();
        
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 1.5f, item);
        //itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 1.5f, ForceMode2D.Impulse);
        
        GameObject.Find("WorldManager").GetComponent<WorldManager>().addListStuff(item, itemWorld.GetComponent<Rigidbody2D>().position);

        
        //GameObject.Find("WorldManager").GetComponent<WorldManager>().addWorldItem(item, itemWorld.GetComponent<Transform>().position);

        return itemWorld;

    }

    

    public void SetItem(Item item) {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        light2D.color = item.GetColor();
        if (item.amount > 1) {
            textMeshPro.SetText(item.amount.ToString());
        } else {
            textMeshPro.SetText("");
        }

    }

    public Item GetItem(){
        return item;
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item){


        

        Transform _transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);


        ItemWorld itemWorld = _transform.GetComponent<ItemWorld>();
        
        itemWorld.SetItem(item);



        return itemWorld;
    } 

    public void DestroySelf(){
        GameObject.Find("WorldManager").GetComponent<WorldManager>().removeListStuff(item, GetComponent<Rigidbody2D>().position);
        //GameObject.Find("WorldManager").GetComponent<WorldManager>().removeWorldItem(item, GetComponent<Transform>().position);
        Destroy(gameObject);
    }

}