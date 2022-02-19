using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;
using QFSW.QC.Actions;
using UnityEngine.SceneManagement;


public class Delete_Data : MonoBehaviour
{
    [Command("delete_all_data")]
    public void Delete(){
        foreach(var key in ES3.GetKeys("SaveFile.es3")){
            ES3.DeleteKey(key);
        }
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
