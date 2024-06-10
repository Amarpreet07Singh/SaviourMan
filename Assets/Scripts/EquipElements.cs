using UnityEngine;

 
public class EquipElements : MonoBehaviour
{
    public GameObject candlePrefab; 
    public GameObject AxePrefab; 
    public GameObject lantran; 
    public Transform leftHand; 
    public GameObject axe; 
    public Transform rightHand;
    GameObject candleInstance;
    GameObject axeInstance;
    public bool hasAxe = false;
    public bool hasLantren = false;

    private void Update()
    {
      //  AnimateWalk();
    }
    void AnimateWalk()
    {
        if(hasLantren)
        {
            candleInstance.transform.position = candleInstance.transform.position  + new Vector3(1f,0,0);
            candleInstance.transform.position = candleInstance.transform.position  - new Vector3(1f,0,0);

        }
        if(hasAxe)
        {
            axeInstance.transform.position = axeInstance.transform.position + new Vector3(1f,0,0);
            axeInstance.transform.position = axeInstance.transform.position - new Vector3(1f,0,0);
        }
    }

    public void Equiplantren()
    {
        
        Debug.Log("enter");
        Destroy(lantran);
        candleInstance = Instantiate(candlePrefab, leftHand);
        candleInstance.transform.localPosition = Vector3.zero;  
        candleInstance.transform.localRotation = Quaternion.identity;
        hasLantren=true;
    }
    public void EquipAxe()
    {
        Debug.Log("enter");
         Destroy(axe);
         axeInstance = Instantiate(AxePrefab,rightHand);
         axeInstance.transform.localPosition = new Vector3(0.100000001f, -0.100000001f, 0);
         axeInstance.transform.localRotation = Quaternion.Euler(new Vector3(331.089996f, 172.580032f, 95.0899963f));
        hasAxe=true;


    }
   
     
}
