using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerDamage = 4;
    public BoxCollider2D bc;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
      if (collision.gameObject.tag != "Enemy"){
          Physics2D.IgnoreCollision(bc, collision.collider);
      }
    
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Enemy"){
            Enemy enemyHealth ;
            enemyHealth = other.gameObject.GetComponent<Enemy>();
            enemyHealth.dealEnemyDamage(playerDamage);

        }

    }




}
