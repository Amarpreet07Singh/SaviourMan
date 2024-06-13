 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update

     
     public GameObject Enemy;
    
     GameObject enemyInstance;
     
     public bool isSpawn = false;
     
      EnemyAttack enemyAttack;
    
    void SpawnEnemy()
    {
        if(!isSpawn) 
        { 
            isSpawn = true;

            Quaternion dir = Enemy.transform.rotation;

            enemyInstance = Instantiate(Enemy,gameObject.transform.position, dir);
            enemyAttack = Enemy.GetComponent<EnemyAttack>();
            enemyAttack.isSpawn = true;
              
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {   
        if(other.CompareTag("Player"))
          SpawnEnemy();
    }
     /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isSpawn = false;
    } */
     
    }
    

 
   

   

     
   










 
 






























 
 
/*using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float detectionRange = 10f; // Range at which the enemy detects the player
    public float fireRate = 1f; // Rate at which the enemy fires
    public LineRenderer lineRenderer; // Reference to the LineRenderer component
    public float patchDelay = 0.1f; // Delay between patches

    private float nextFireTime; // Time of next fire
    bool inRange = false;
    void Update()
    {
        // Check if player is within detection range
        if (inRange)
        {
            // Check if it's time to fire
            if (Time.time >= nextFireTime)
            {
                // Fire patches of rays
                StartCoroutine(FirePatches());
                nextFireTime = Time.time + 1f / fireRate; // Update next fire time
            }
        }
    }

    IEnumerator FirePatches()
    {
        // Enable LineRenderer
        lineRenderer.enabled = true;

        // Calculate number of patches
        int numPatches = 5;
        for (int i = 0; i < numPatches; i++)
        {
            // Generate random direction for each patch
            Vector3 direction = Random.insideUnitSphere;

            // Set LineRenderer positions
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + direction * detectionRange);

            yield return new WaitForSeconds(patchDelay);
        }

        // Disable LineRenderer after firing patches
        lineRenderer.enabled = false;
    }
}
*/