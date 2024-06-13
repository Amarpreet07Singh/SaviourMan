using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GunShot : MonoBehaviour
{
    float damage = 13f;
    float timeGap = 0f;
    float rangeOFshot = 100f;
    LineRenderer gunRay;
    ParticleSystem gunFlare;
    Ray shootRay;
    RaycastHit shootHit;
    public LayerMask shootObject;
    AudioSource gunShotAudio;
    Light gunLight;
    EnemyHealth enemyHealth;
    EnemyHealth2 enemyHealth2;
    BigEnemyHealth enemyHealthBig;
    GameObject scoreManager;
    ScoreManager score;
    bool isAlive = false;
    void Awake()
    {

        gunFlare = GetComponent<ParticleSystem>();
        gunRay = GetComponent<LineRenderer>();
        gunShotAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        scoreManager = GameObject.FindWithTag("Score");
    }

    private void Update()
    {
        timeGap += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeGap >= 0.15f && Time.deltaTime != 0)
        {

            FireBullet();
        }
        if (timeGap > 0.03f)
        {

            gunLight.enabled = false;
            gunRay.enabled = false;
        }
        

    }
    void FireBullet()
    {
        timeGap = 0f;
        gunShotAudio.Play();

        gunLight.enabled = true;

        gunFlare.Stop();
        gunFlare.Play();

        gunRay.enabled = true;
        gunRay.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay.origin, shootRay.direction, out shootHit, rangeOFshot, shootObject))
        {
            Debug.Log(shootHit.collider.tag);
            if (shootHit.collider.tag == "Enemy")
            {
                Debug.Log("Called Enemy");
               
                enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    if (enemyHealth.Health > 0)
                    {
                        isAlive = false;
                        enemyHealth.TakeDamage(damage, shootHit.point);
                    }

                }
                if (enemyHealth.Health <= 0 && !isAlive)
                {
                    isAlive = true;
                    score = scoreManager.GetComponent<ScoreManager>();
                    score.UpdateScore();
                }
                gunRay.SetPosition(1, shootHit.point);
            }
            else if(shootHit.collider.tag == "BigEnemy")
            {
                Debug.Log("BigEnemyHitted");
                enemyHealthBig = shootHit.collider.GetComponent<BigEnemyHealth>();
                if (enemyHealthBig != null)
                {
                    if (enemyHealthBig.Health > 0)
                    {
                        isAlive = false;
                        enemyHealthBig.TakeDamage(damage);
                    }

                }
                if (enemyHealthBig.Health <= 0 && !isAlive)
                {
                    isAlive = true;
                    score = scoreManager.GetComponent<ScoreManager>();
                    score.UpdateScore();
                }
                gunRay.SetPosition(1, shootHit.point);
            }
            else 
            {
                Debug.Log("Called Enemy 22 ");
                enemyHealth2 = shootHit.collider.GetComponent<EnemyHealth2>();
                if (enemyHealth2 != null)
                {
                    if (enemyHealth2.Health > 0)
                    {
                        isAlive = false;
                        enemyHealth2.TakeDamage(damage);
                    }

                }
                if (enemyHealth2.Health <= 0 && !isAlive)
                {
                    isAlive = true;
                    score = scoreManager.GetComponent<ScoreManager>();
                    score.UpdateScore();
                }
                gunRay.SetPosition(1, shootHit.point);
            }
            
        }
        else
        {
            gunRay.SetPosition(1, shootRay.origin + shootRay.direction * rangeOFshot);
        }
    }










}
































