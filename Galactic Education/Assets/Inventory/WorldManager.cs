using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[ES3Serializable]
public class Stuff {
    public Item item;
    public Vector3 position;

    public Stuff(Item _item, Vector3 _position){
        item = _item;
        position = _position;
    }

}

public class WorldManager : MonoBehaviour
{

    private List<Stuff> listStuff;
    //Sets the List
    public void Start(){
        if(!ES3.KeyExists("save_listStuff")) {
            listStuff = new List<Stuff>();
            
            ES3.Save("save_listStuff", listStuff);
        } else { 
            listStuff = ES3.Load<List<Stuff>>("save_listStuff");
            foreach (Stuff stuff in listStuff){
                ItemWorld.SpawnItemWorld(stuff.position,stuff.item);
            }

        }
    }
    
    //Add
    public void addListStuff(Item item, Vector3 position){

        if(ES3.KeyExists("save_listStuff")) {
            listStuff = ES3.Load<List<Stuff>>("save_listStuff");
        }

        Stuff stuff = new Stuff(item, position);
        listStuff.Add(stuff);

        ES3.Save("save_listStuff", listStuff);

    }

    public void removeListStuff(Item _item, Vector3 _position){

        Stuff removeStuff = null;

        if(ES3.KeyExists("save_listStuff")) {
            listStuff = ES3.Load<List<Stuff>>("save_listStuff");
        }
    
        foreach (Stuff stuff in listStuff){

            
            if ((stuff.item.itemType == _item.itemType) && (stuff.item.amount == _item.amount) && (stuff.position == _position)){
                removeStuff = stuff;
                break;
            }
        }

        listStuff.Remove(removeStuff);

        ES3.Save("save_listStuff", listStuff);


    }

}
