using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem hitParticle;
    public float Health = 50;
    //EnemySpawn enemySpawn;
    EnemyAttack enemyAttack;
    Animator animator;
    bool isAlive = false;
    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Health);
        if(Health <= 0&&!isAlive)
        {
              isAlive = true;
            //animator.SetTrigger("IsDead");
              Destroy(gameObject,0.4f);
              Destroy(gameObject.GetComponentInParent<EnemyAttack>(),0.4f);
           // StartCoroutine("Finish");
              enemyAttack.enabled = false;

        }
    }
   /* IEnumerator Finish()
    {
        
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    //}*/
    public void TakeDamage(float damage,Vector3 point)
    {   
        hitParticle.transform.position = point;
        hitParticle.Play();
        Health -= damage;
    }
}
