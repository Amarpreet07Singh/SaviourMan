using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack3 : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    GameObject Player;
      float damage = 10f;
    float timeOfAttack = 1f;
    Animator animator;
    //Image damageImage;
    //Color damageColor = new Color(1f, 0, 0, 0.1f);
    bool isCollided;
    EnemyMovement enemy;
    //bool isDamage = false;
    void Start()
    {

        Player = GameObject.FindWithTag("RightHand");
        playerHealth = Player.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyMovement>();
        isCollided = false;
    }
    private void Update()
    {
        if (playerHealth.health <= 0)
        {
            enemy.enabled = false;
            animator.SetBool("IsAttack", false);
        }
        else
        {
            GiveDamage();
            //Damage();
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
            animator.SetBool("IsAttack",true);
            playerHealth.TakeDamage(damage);
            timeOfAttack = 1f;

        }
        else if (timeOfAttack > 0)
        {

            timeOfAttack -= Time.deltaTime;

        }
    }
    // Update is called once per frame

}
