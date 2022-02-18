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
        ES3.DeleteFile("save_PlayerPos");
        ES3.DeleteFile("alreadyShuffled");
        ES3.DeleteFile("save_tiles");
        ES3.DeleteFile("save_isSlidingPuzzleCompleted");
        ES3.DeleteFile("save_backupTiles");
        
        ES3.DeleteFile("save_itemList");
        ES3.DeleteFile("save_SpiritPoints");
        ES3.DeleteFile("save_listStuff");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
