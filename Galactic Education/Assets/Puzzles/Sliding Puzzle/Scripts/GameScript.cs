using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] public Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    private int emptySpaceIndex = 8;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        //Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit){
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 4){
                    Vector2 lastEmptySpacePosition = new Vector3(emptySpace.position.x, emptySpace.position.y, 0);
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

        int correctTiles = 0;
        foreach (var a in tiles){
            if (a != null) {
                if (a.inRightPlace)
                    correctTiles++;
            }
        }

        if (correctTiles == tiles.Length - 1){
            Debug.Log (message: "You Won");
        }


    }

    public void Shuffle(){
        if (emptySpaceIndex != 8){
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[15].targetPosition = emptySpace.position;
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
