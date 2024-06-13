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
         DestroyImmediate(axe,true);
         axeInstance = Instantiate(AxePrefab,rightHand);
         axeInstance.transform.localPosition = new Vector3(-0.148000002f, -0.0439999998f, -0.272000015f);
         axeInstance.transform.localRotation = Quaternion.Euler(new Vector3(282.553467f, 334.502899f, 103.727348f));
         hasAxe=true;


    }
   
     
}
