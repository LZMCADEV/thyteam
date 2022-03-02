using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Movement Script, No Collision

public class Player_Movement : MonoBehaviour
{
    //This sets the movement speed for the player
    public float moveSpeed = 5f;
    public Animator animator;

    private string lastBool = "";

    //You're going to have to make a RigidBody2D component for the player and attach it to the variable rb.
    public Rigidbody2D rb;

    //This can store both horizontal and vertical movement
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // More reliable with Key Input
    void Update()
    {
        // This checks the horizontal axis, which is built into Unity. WASD and Arrow Keys.
        // This return a value of -1 or 1.
        // Stores it in the horizontal area
        movement.x = Input.GetAxisRaw("Horizontal");
        // Stores it in the vertical area
        movement.y = Input.GetAxisRaw("Vertical");

        if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) ||  ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))) ){
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Up";
        } else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)  ||  ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))) ){
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Up";
        } else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)  ||  ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))) ){
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Up";
        } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)  ||  ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))) ){
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Down";
        } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)  ||  ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))) ){
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Down";
        } else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)  ||  ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))) ){
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Down";
        } else if (Input.GetKey(KeyCode.UpArrow)  ||  Input.GetKey(KeyCode.W) ){
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Up";
        } else if (Input.GetKey(KeyCode.DownArrow)  ||  Input.GetKey(KeyCode.S) ){
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Down";
        } else if (Input.GetKey(KeyCode.LeftArrow)  ||  Input.GetKey(KeyCode.A) ){
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Left";
        } else if (Input.GetKey(KeyCode.RightArrow)  ||  Input.GetKey(KeyCode.D) ){
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Idle Up", false);
            animator.SetBool("Idle Down", false);
            animator.SetBool("Idle Right", false);
            animator.SetBool("Idle Left", false);
            lastBool = "Right";
        } else {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            if (lastBool == "Up"){
                animator.SetBool("Idle Up", true);
                animator.SetBool("Idle Down", false);
                animator.SetBool("Idle Right", false);
                animator.SetBool("Idle Left", false);
            } else if (lastBool == "Down"){
                animator.SetBool("Idle Up", false);
                animator.SetBool("Idle Down", true);
                animator.SetBool("Idle Right", false);
                animator.SetBool("Idle Left", false);
            } else if (lastBool == "Right"){
                animator.SetBool("Idle Up", false);
                animator.SetBool("Idle Down", false);
                animator.SetBool("Idle Right", true);
                animator.SetBool("Idle Left", false);
            } else if (lastBool == "Left"){
                animator.SetBool("Idle Up", false);
                animator.SetBool("Idle Down", false);
                animator.SetBool("Idle Right", false);
                animator.SetBool("Idle Left", true);
            }
 





        }
        }

    

    // More Reliable with Physics
    void FixedUpdate(){
        // This allows the player to move
        // Time.fixedDeltaTime allows the player to have a more reliable movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
