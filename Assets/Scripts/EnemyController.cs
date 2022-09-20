using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float detectionRadius;
    public float attackRange;

    private float distanceToPlayer;
    
    private GameObject player;
    private NavMeshAgent agent;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceToPlayer <= detectionRadius && distanceToPlayer > attackRange)
        {
            agent.SetDestination(player.transform.position);
            
            anim.SetBool("Running", true);
        }
        else if(distanceToPlayer < attackRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            agent.SetDestination(transform.position);
            
            transform.LookAt(player.transform);
            
            anim.SetTrigger("Attack");
        }
        else
        {
            agent.SetDestination(transform.position);
            
            anim.SetBool("Running", false);
        }
    }
}
