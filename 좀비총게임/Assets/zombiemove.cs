using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class zombiemove : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = 2.0f;
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        
    }
    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
        ZombieSpeed();
    }
    void ZombieSpeed()
    {
       
        if (timer.time >= 20.0f && timer.time < 30.0f)
        {
            agent.speed = 4.0f;
        }
    
        if (timer.time >= 40.0f && timer.time < 50.0f)
        {
            agent.speed = 6.0f;
        }
        if (timer.time >= 50.0f)
        {
            agent.speed = 7.0f;
        }
    }
  
    void MoveToTarget()
    {
        agent.SetDestination(player.position);
    }
    


}

