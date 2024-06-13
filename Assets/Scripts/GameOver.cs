using System.Collections;
 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /*public GameObject panel;
    public GameObject Scene1;
    public GameObject Scene2;
    public GameObject cam;
    public Camera cam2;*/
    // Start is called before the first frame update
    public PlayerHealth playerhealth;
    //public GunShot gun;
    public Animator animator;
     
    bool isCalled = false;
    public BigEnemyHealth bigenemyhealth;
  
    // Update is called once per frame
    void Update()
    {
        if ((playerhealth.health <= 0 )  && !isCalled)
        {
            Debug.Log("Player Die");
            //gun.enabled = false;
            animator.SetTrigger("GameOver");

            //playerhealth.enabled = false ;
            isCalled = true;
            StartCoroutine("Restart");
        }
         
        
    }
    IEnumerator Restart()
    {
         yield return new WaitForSeconds(3f);
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
         SceneManager.LoadScene(0);

    }
}
