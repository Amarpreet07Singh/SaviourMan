 
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy;
    public Transform [] p_transform;
    public float spawnGapTime = 0f;
    public float   count;
    public GameObject EntryPoint;
    EntryPointScript entryScript;
     //public Animator animator1;
     public Animator animator2;
    bool allDead = false;
    public GameObject wall;
    private void Start()
    {
        entryScript = EntryPoint.GetComponent<EntryPointScript>();
    }
    // Update is called once per frame
    private void Update()
    {
        
        if(entryScript.isVisible && spawnGapTime>=4f&&Time.deltaTime!=0&&count>0&&!allDead)
        {
           
            SpawnEnemy();
        }
        else
        {  
            spawnGapTime += Time.deltaTime;
        }
        if(count<=0&&!allDead)
        {
            animator2.SetBool("TextAfter", true);
            allDead = true;
            Destroy(wall, 2f);
        }
         
    }

    void SpawnEnemy()
    {   
        spawnGapTime = 0f;
        int indexT =  Random.Range(0, p_transform.Length);
        int indexE =  Random.Range(0, enemy.Length);
        Instantiate(enemy[indexE], p_transform[indexT].position, p_transform[indexT].rotation);
        count--;
    }
  

}
