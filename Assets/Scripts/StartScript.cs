using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Firstpanel;
    public GameObject Secondpanel;
    public GameObject Scene1;
    public GameObject Scene2;
     //AudioSource audioSource;
    private void Start()
    {
        // audioSource = GetComponent<AudioSource>();
    }

    public void OnClickIntro()
    {
        
        //audioSource.Play();
        Debug.Log("Clicked");
        Firstpanel.SetActive(false);
        Secondpanel.SetActive(true);
        /* panel.SetActive(false);
         Scene1.SetActive(true);
         Scene2.SetActive(true);*/
        //cam2.enabled = false;
        //cam.SetActive(true);
    }
    public void OnClickControls()
    {
        //audioSource.Play();
        Secondpanel.SetActive(false);
        Scene1.SetActive(true);
        Scene2.SetActive(true);
    }
}
