using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WrongPath : MonoBehaviour
{
    // Start is called before the first frame update
    //TextMeshProUGUI wrongPath;
    public Animator animator;
    bool isEntered = false;
    private void OnTriggerEnter(Collider other)
    {
        isEntered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        isEntered = false;
    }

    private void Update()
    {
        if(isEntered)
        {
            animator.SetBool("WrongPath",true);
        }
        else
        {
            animator.SetBool("WrongPath",false);
        }
    }
}
