using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[ES3Serializable]

public class gameStuff {
    // Start is called before the first frame update
    public Item item;
    public Vector3 position;

    
    public void Stuff(Item _item, Vector3 _position){
        item = _item;
        position = _position;
    }


}
