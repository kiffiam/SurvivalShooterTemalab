using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedMovement : MonoBehaviour{

   Transform playerTransform;
    GameObject player;
    PlayerStats playerStats;
    EnemyStats enemyStats;
    EnemyRangedAttack enemyRangedAttack;

    NavMeshAgent nav;
 
    private void Awake()
    {
        //finding the coordinates of the player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        enemyRangedAttack = GetComponent<EnemyRangedAttack>();
        enemyStats = GetComponent<EnemyStats>();

        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = enemyRangedAttack.range;
    }

    // Update is called once per frame
    void Update () {
        if (enemyStats.currentHealth > 0 && 
            playerStats.currentHealth > 0)
            //&& enemyRangedAttack.playerDistance >= enemyRangedAttack.range)
        {
            nav.SetDestination(playerTransform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
