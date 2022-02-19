using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

[CommandPrefix("slidingPuzzle.")]
public class GameScript : MonoBehaviour
{
    [SerializeField] public Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    private int emptySpaceIndex = 8;

    
    public Variable_Bool isSlidingPuzzleCompleted;

    // Start is called before the first frame update


    void Start()
    {

        _camera = Camera.main;
        
        
        if(ES3.KeyExists("alreadyShuffled")) {
            emptySpaceIndex = ES3.Load<int>("save_emptySpaceIndex");
            tiles = ES3.Load<TilesScript[]>("save_tiles");
            isSlidingPuzzleCompleted.value = ES3.Load<bool>("save_isSlidingPuzzleCompleted");



        } else {
            ES3.Save("save_emptySpaceIndex", emptySpaceIndex);
            ES3.Save("save_backupTiles", tiles);
            Shuffle();
            ES3.Save("save_tiles", tiles);
            ES3.Save("alreadyShuffled", true);
            isSlidingPuzzleCompleted.value = false;
            ES3.Save("save_isSlidingPuzzleCompleted", isSlidingPuzzleCompleted.value);
        }
        


        

        

    }

    // Update is called once per frame
    [Command("solve")]
    public void Solve(){
        tiles = ES3.Load<TilesScript[]>("save_backupTiles");
        
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0)&& !isSlidingPuzzleCompleted.value ){
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit){
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 4){
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;

                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                    
                }
            }

        }
        if (!isSlidingPuzzleCompleted.value){
            int correctTiles = 0;
            foreach (var a in tiles){
                if (a != null) {
                    if (a.inRightPlace)
                        correctTiles++;
                }
            }

            if (correctTiles == tiles.Length - 1){
                isSlidingPuzzleCompleted.value = true;
                
            }
        }
        ES3.Save("save_emptySpaceIndex", emptySpaceIndex);
        ES3.Save("save_tiles", tiles);



    }
    [Command("shuffle")]
    public void Shuffle(){
        isSlidingPuzzleCompleted.value = false;
        if (emptySpaceIndex != 8){
            
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn8LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 8;
        }
        int invertion = 1;
        do{
            for (int i = 0; i <= 7; i++) {
            if (tiles[i] != null){
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0,7);
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;

                //Checking if is solveable

                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;

                }

                invertion = GetInversions();

            }
        } while (invertion%2 != 0);

        ES3.Save("save_emptySpaceIndex", emptySpaceIndex);
        ES3.Save("save_tiles", tiles);
    }

    public int findIndex(TilesScript ts){
        for (int i = 0;i < tiles.Length; i++){
            if (tiles[i] != null) {
                if (tiles[i] == ts){
                    return i;
                }
            }
        }
        return -1;
    }


    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0;i < tiles.Length;i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }

}
