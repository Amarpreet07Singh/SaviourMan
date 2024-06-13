using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    GameObject Player;
    public float damage ;
    float timeOfAttack = 1f;
    
    //Image damageImage;
    //Color damageColor = new Color(1f, 0, 0, 0.1f);
    bool isCollided;
    //EnemyMovement enemy;
    //bool isDamage = false;
    void Start()
    {

        Player = GameObject.FindWithTag("RightHand");
        playerHealth = Player.GetComponent<PlayerHealth>();
        
        //enemy = GetComponent<EnemyMovement>();
        isCollided = false;
    }
    private void Update()
    {
        if (playerHealth.health > 0)
        {
            GiveDamage();

        }
        

    }
    /* void Damage()
     {
         if (isDamage)
         {
             Debug.Log("Color Change");
             damageImage.color = damageColor;
         }
         else
         {
             damageImage.color = Color.Lerp(damageImage.color, Color.clear, timeOfAttack);
         }
         isDamage = false;
     }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {

            isCollided = true;

        }
        /* if (other.gameObject.CompareTag("Player")&&timeOfAttack <= 0 && playerHealth.CurHealth > 0)
         {
             playerHealth.EnemyAttack(damage);
             timeOfAttack = 2f;
         }
         else
         {
             timeOfAttack -= Time.deltaTime;
         }*/

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            isCollided = false;
        }

    }
    private void GiveDamage()
    {
        if (isCollided && timeOfAttack <= 0 && playerHealth.health > 0)
        {
            Debug.Log("Enter Attack2");
            
            playerHealth.TakeDamage(damage);
            timeOfAttack = 1f;

        }
        else if (timeOfAttack > 0)
        {

            timeOfAttack -= Time.deltaTime;

        }
    }
}
