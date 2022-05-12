using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Animator animator;

    public int maxStamina = 100;
    public int currentStamina = 100;
    public StaminaBar staminaBar;
    public int tempStaminaDecreaseRate = 10;
    public float rechargeRate = 2f;
    float rechargeTime;

    public float attackRate = 1f;
    
    float nextAttackTime = 0f;
    // Update is called once per frame

    void Awake()
    {
        currentStamina = maxStamina;

    }

    void Update()
    {
        
        if (Time.time >= nextAttackTime && (currentStamina - tempStaminaDecreaseRate) >= 0){
            if (Input.GetMouseButtonUp(0)){
                Attack();
                currentStamina -= tempStaminaDecreaseRate;
                nextAttackTime = Time.time + 1f/attackRate;
                staminaBar.setStamina(currentStamina);
            }
        }

        if (Time.time >= rechargeTime && currentStamina < maxStamina){
            rechargeTime = Time.time + 1f/rechargeRate;
            currentStamina += 1;
            staminaBar.setStamina(currentStamina);

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
