using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic Movement Script, No Collision

public class Player_Movement : MonoBehaviour
{
    //This sets the movement speed for the player
    public float moveSpeed = 5f;
    public Animator animator;

    

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

        if (movement.x == 0 && movement.y == 0){
            animator.SetFloat("Speed", 0);
        } else {
            animator.SetFloat("Horizontal Movement", movement.x);
            animator.SetFloat("Vertical Movement", movement.y);
            animator.SetFloat("Speed", 1);
            
        }

        
        
        

    }

    

    // More Reliable with Physics
    void FixedUpdate(){
        // This allows the player to move
        // Time.fixedDeltaTime allows the player to have a more reliable movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
