using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int playerDamage = 4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Enemy"){
            Enemy enemyHealth ;
            enemyHealth = other.gameObject.GetComponent<Enemy>();
            enemyHealth.dealEnemyDamage(playerDamage);

        }

    }




}
