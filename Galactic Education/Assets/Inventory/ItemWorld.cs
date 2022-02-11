using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
 
public class ItemWorld : MonoBehaviour
{

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item){
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;

    private SpriteRenderer spriteRenderer;

    public Light2D light2D;


    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        

    }



    public void SetItem(Item item) {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        light2D.color = item.GetColor();

    }

    public Item GetItem(){
        return item;
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }

}
