 
using UnityEngine;

public class SpawnBigEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public Transform[] p_transform;
    public float spawnGapTime;
    public float count;
    public GameObject EntryPoint;
    EntryPointScript entryScript;
    //public Animator animator1;
    public Animator animator2;
    bool allDead = false;
    
    private void Start()
    {
        entryScript = EntryPoint.GetComponent<EntryPointScript>();
    }
    // Update is called once per frame
    private void Update()
    {

        if (entryScript.isVisible && spawnGapTime >= 4f && Time.deltaTime != 0 && count > 0 && !allDead)
        {
            SpawnEnemy();
        }
        else if(entryScript.isVisible)
        {
            spawnGapTime += Time.deltaTime;
        }
       /* if (count <= 0 && !allDead)
        {
            animator2.SetBool("TextAfter", true);
            allDead = true;
           
        }*/

    }

    void SpawnEnemy()
    {
        
        int index = Random.Range(0, p_transform.Length);

         Instantiate(enemy, p_transform[index].position, p_transform[index].rotation);
         
         

        count--;
    }


}
