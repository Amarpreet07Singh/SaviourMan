using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Slider sliderHealth;
    public float health = 200;
    public AudioClip[] Clips;
     AudioSource audioSource;
    bool isAlive = true;
     
    //PLayerMovement pLayerMovement; 
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0&&isAlive) 
        {    
            isAlive = false;
            audioSource.clip = Clips[1];
            audioSource.Play(); 

            //TakeDamage(5);
             
            
        }
        sliderHealth.value = health;
    }
   /* IEnumerator Reload()
    {   
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);

    }*/
    public void TakeDamage(float damage)
    {   
        audioSource.clip = Clips[0];
        audioSource.Play();
        Debug.Log("TakeDamage");
        sliderHealth.value = health;
       // Debug.Log(sliderHealth.value);
        health -= damage;
    }
}
