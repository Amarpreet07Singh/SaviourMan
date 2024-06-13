using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
      GameObject Player;
      NavMeshAgent NavMeshAgent;
    void Start()
    {
        Player = GameObject.FindWithTag("RightHand");
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent.SetDestination(Player.transform.position);
    }
}
