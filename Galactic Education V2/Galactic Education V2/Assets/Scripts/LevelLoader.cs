using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator transition;



    public float transitionTime = 1f;

    public void Update(){
        
    }

    public void LoadSlidingPuzzle(){
        
        StartCoroutine(LoadLevel("SlidingPuzzle_Scene"));
        
        
    }

    public void LoadDistortClassroom(){
        
        StartCoroutine(LoadLevel("Distort Classroom"));
        
        
    }

    IEnumerator LoadLevel(string levelName){

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        SceneManager.LoadScene(levelName);

        Debug.Log("Loaded Level " + levelName);

    }

}
