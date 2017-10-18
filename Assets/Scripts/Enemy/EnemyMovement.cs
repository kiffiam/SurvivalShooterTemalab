using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //private variables
    //player's position
    Transform player;

    //Player's health
    PlayerStats playerStats;

    //Enemy mob's stats, health
    EnemyStats enemyStats;

    //AI following the player/portal
    NavMeshAgent nav;

    private void Awake()
    {
        //finding the coordinates of the player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerStats = player.GetComponent<PlayerStats>();

        enemyStats = GetComponent<EnemyStats>();

        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
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
