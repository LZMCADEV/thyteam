using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    

    private List<Item> itemWorldList;
    private List<Vector3> posWorldList;
    
    
    void Start(){
        if(!ES3.KeyExists("save_posWorldList")) {
            posWorldList = new List<Vector3>();
            itemWorldList = new List<Item>();
        }

        if(ES3.KeyExists("save_posWorldList")) {
            
            itemWorldList = GameObject.Find("WorldManager").GetComponent<WorldManager>().checkCurrentItem();
            posWorldList = GameObject.Find("WorldManager").GetComponent<WorldManager>().checkCurrentPos();

            int tempIndex = 0;
            
            foreach (Item item in itemWorldList){
                
                ItemWorld.SpawnItemWorld(posWorldList[tempIndex], item);
                tempIndex++;
            }
        }
    }

    public List<Vector3> checkCurrentPos() {
        if(ES3.KeyExists("save_posWorldList")) {
            posWorldList = ES3.Load<List<Vector3>>("save_posWorldList");
        }

        return posWorldList;
    }

    public List<Item> checkCurrentItem() {
        if(ES3.KeyExists("save_itemWorldList")) {
            itemWorldList = ES3.Load<List<Item>>("save_itemWorldList");
        }

        return itemWorldList;
    }


    public void addWorldItem(Item item, Vector3 pos){

        if(ES3.KeyExists("save_itemWorldList")) {
            itemWorldList = ES3.Load<List<Item>>("save_itemWorldList");
        }
        if(ES3.KeyExists("save_posWorldList")) {
            posWorldList = ES3.Load<List<Vector3>>("save_posWorldList");
        }

        itemWorldList.Add(item);
        posWorldList.Add(pos);

        ES3.Save("save_itemWorldList", itemWorldList);
        ES3.Save("save_posWorldList", posWorldList);

    }

    public void removeWorldItem(Item item, Vector3 pos){

        if(ES3.KeyExists("save_itemWorldList")) {
            itemWorldList = ES3.Load<List<Item>>("save_itemWorldList");
        }
        if(ES3.KeyExists("save_posWorldList")) {
            posWorldList = ES3.Load<List<Vector3>>("save_posWorldList");
        }
        itemWorldList.Remove(item);
        posWorldList.Remove(pos);

        ES3.Save("save_itemWorldList", itemWorldList);
        ES3.Save("save_posWorldList", posWorldList);

    }


}
