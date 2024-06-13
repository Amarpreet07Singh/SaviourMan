using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health = 100;
    //EnemySpawn enemySpawn;
    EnemyAttack3 enemyAttack;
    EnemyMovement enemyMovement;
    Animator animator;
    bool isAlive = false;
    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack3>();
        animator = GetComponent<Animator>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Health);
        if (Health <= 0 && !isAlive)
        {
            isAlive = true;
            animator.SetTrigger("Dead");

            Destroy(gameObject, .4f);
           // Destroy(gameObject.GetComponentInParent<EnemyAttack>(), 0.4f);
            // StartCoroutine("Finish");
             enemyAttack.enabled = false;
             enemyMovement.enabled = false;

        }
    }
    /* IEnumerator Finish()
     {

         yield return new WaitForSeconds(4f);
         Destroy(gameObject);
     //}*/
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
