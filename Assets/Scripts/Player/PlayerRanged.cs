using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRanged : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f; //changes by monsters
    public int attackDamage = 10; //changes by monsters

    //private variables
    Animator anim;
    GameObject player;
    PlayerStats playerStats;
    EnemyStats enemyStats;

    bool playerInRange; //is the player in range, movement-> backing?
    float timer;

    private void Awake()
    {
        //finding the players reference
        player = GameObject.FindGameObjectWithTag("Player");
        //
        playerStats = player.GetComponent<PlayerStats>();

        enemyStats = GetComponent<EnemyStats>();

        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyStats.currentHealth > 0)
        {
            Attack();
        }

        if (playerStats.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }

    }

    void Attack()
    {
        timer = 0f;

        //shooting, player can move away from it, makes damage only the player is hit
        //raycast?
    }

    //player out of range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    //player in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }
}
