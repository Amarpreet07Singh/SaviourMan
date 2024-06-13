using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
     GameObject player;
    
     //LineRenderer lineRay;
     GameObject enemyInstance;
    float damage = 8f;
    float timeGap = 0f;
    float rangeOFshot = 10f;
    //LineRenderer gunRay;
    //ParticleSystem gunFlare;
    Ray shootRay;
    RaycastHit shootHit;
    public LayerMask shootObject;
    // AudioSource gunShotAudio;
    //Light gunLight;
    public  bool isSpawn = false;
    PlayerHealth playerHealth;
   
    //  CharacterController player;
    private void Awake()
    {
        //gunFlare = GetComponent<ParticleSystem>();
       // lineRay = GetComponent<LineRenderer>();
        //  gunShotAudio = GetComponent<AudioSource>();
        //gunLight = GetComponent<Light>();
        player = GameObject.FindWithTag("RightHand");
       
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (isSpawn&& distance<=5f)
        {  
           
             Debug.Log("Entered Enemy");
            //lineRay.SetPosition(1, player.transform.position);

            timeGap += Time.deltaTime;
            if (timeGap >= 0.7f && Time.deltaTime != 0 )
            {
                AttackPlayer();
            }
            if (timeGap > 0.02f)
            {

               // gunLight.enabled = false;
               // lineRay.enabled = false;
            }


        }
       
         
        
    }
    /*private void OnTriggerExit(Collider other)
    {
        isSpwan = false;
    }*/
    void AttackPlayer()
    {

        //lineRay.enabled = true;
        // gunRay.enabled = true;
        timeGap = 0f;
        //gunShotAudio.Play();

       // gunLight.enabled = true;

        //gunFlare.Stop();
        //gunFlare.Play();

        //lineRay.enabled = true;
        //lineRay.SetPosition(0, transform.position + new Vector3(0f, 1.2f, 0));
        //lineRay.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay.origin, shootRay.direction, out shootHit, rangeOFshot))
        {
            Debug.Log("Entered in Ray");
            playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null && playerHealth.health>0)
            {
                playerHealth.TakeDamage(damage);
              //  lineRay.SetPosition(1, shootHit.point);
            }
           
            
        }
        
    }
}
