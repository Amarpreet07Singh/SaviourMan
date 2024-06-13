using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigEnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    //EnemySpawn enemySpawn;
    BigEnemyAttack enemyAttack;
    Animator animator;
    public Animator animcanvas;
    
    public bool isAlive = false;
    private void Start()
    {
        enemyAttack = GetComponent<BigEnemyAttack>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
         Debug.Log(Health);
        if (Health <= 0 && !isAlive)
        {
             isAlive = true;
             animator.SetTrigger("IsDead");
            Destroy(gameObject);
            SceneManager.LoadScene(0);
            //animator.SetTrigger("Victory");
            //StartCoroutine("RestartGame");

            //Destroy(gameObject.GetComponentInParent<BigEnemyAttack>(), 0.4f);

            enemyAttack.enabled = false;

        }
        /* IEnumerator RestartGame()
        {
           //
            yield return new WaitForSeconds(2f);
            

        } */
    }
   
   
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}
