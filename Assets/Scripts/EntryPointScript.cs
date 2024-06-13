using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntryPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool  isVisible = false;
      bool  enterUpdate = false;
    public TextMeshProUGUI intsruct;
    private void OnTriggerEnter(Collider other)
    {
        
        isVisible = true;
    }
    private void Update()
    {
        if (isVisible&&!enterUpdate)
        {
            enterUpdate = true;
            intsruct.text = "Kill Monster";
        }
    }
}
