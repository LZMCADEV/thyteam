using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;
    
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if (Input.GetMouseButtonUp(0)){
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
        
    }

    public void Attack(){
        //animator.SetBool("Attack", true);
        animator.SetTrigger("Attacking");
        StartCoroutine(DelayedAttack(animator.GetCurrentAnimatorStateInfo(0).length));
        
        
    }

    IEnumerator DelayedAttack(float _delay = 0){
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //yield return new WaitForSeconds(_delay);
        
    }
}
