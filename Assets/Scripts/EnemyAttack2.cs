using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    PlayerHealth Playerhealth;
    float damage = 10f;
    float timeGap = 0;
    public EnemyHealth enemyHealth;
    bool isAlive = true;
    bool isEnter = false;
    void Start()
    {
        player = GameObject.FindWithTag("RightHand");
        Playerhealth = player.GetComponent < PlayerHealth >();

    }

    // Update is called once per frame

    private void Update()
    {
        if(isEnter)
        {
            Debug.Log("enter Attack2");


            Debug.Log(enemyHealth.Health);
            if (timeGap > 1f && Time.deltaTime != 0 && isAlive)
            {

                timeGap = 0;
                Playerhealth.TakeDamage(damage);
            }
            else
            {
                timeGap += Time.deltaTime;
            }
            if (enemyHealth.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {   
        if(other.gameObject == player)
        {
            isEnter = true;
        }
       
        
            
        
    }
   
}
