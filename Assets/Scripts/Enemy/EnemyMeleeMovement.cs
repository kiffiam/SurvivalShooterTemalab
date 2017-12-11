using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeMovement : MonoBehaviour
{
    
    public Transform player;

    PlayerStats playerStats;

    EnemyStats enemyStats;

    public NavMeshAgent nav;

    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

       playerStats = player.GetComponent<PlayerStats>();

        enemyStats = GetComponent<EnemyStats>();

        nav = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
       if (enemyStats.currentHealth > 0 && playerStats.currentHealth > 0)
       {
            nav.SetDestination(player.position);
       }
       else
        {
            nav.enabled = false;
        }

    }
}
