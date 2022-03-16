using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int EnemyHealth = 100;
    private TextMeshPro textMeshPro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
        textMeshPro.SetText(EnemyHealth.ToString());
    }

    public void dealEnemyDamage(int damage){

        EnemyHealth -= damage;

        if (EnemyHealth <= 0){
            Destroy(gameObject);
        }

    }
}
