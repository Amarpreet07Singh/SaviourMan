using System.Collections;
using TMPro;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public TextMeshProUGUI instruct;
    public Transform teleportPosition; // The position where you want to teleport the player
    bool isEnter = false;
     CharacterController characterController;
    GameObject player;
    public Animator animator;
    public PlayerMovement playerMovement;
    public PlayerHealth playerHealth;
    // This method is called when another collider enters the trigger collider
    void OnTriggerEnter(Collider other)
    {    
        if(other.CompareTag("Player"))
        {
            
            player = other.gameObject;
            isEnter = true;
            characterController = other.GetComponent<CharacterController>();
        }
            
        // Check if the object entering the trigger has a character controller attached

    }
    private void Update()
    { 
        if (isEnter)
        {
            playerHealth.health = 300;
            isEnter = false;
            NextScene();
        }
    }
    void NextScene()
    {

        StartCoroutine("MoveToNext");
        
    }
    IEnumerator MoveToNext()
    {
        animator.SetBool("NextLevel",true);
        playerMovement.enabled = false;
        instruct.text = "Kill Enemies To Open Gate";
        yield return new WaitForSeconds(3f);
        playerMovement.enabled = true;
        animator.SetBool("NextLevel", false);
       
            Debug.Log("ENtered in the next level");
            // Teleport the player to the specified position
             characterController.enabled = false; // Disable the character controller temporarily to prevent physics glitches
            player.transform.position = teleportPosition.position;
            characterController.enabled = true; // Re-enable the character controller
         
    }
}
