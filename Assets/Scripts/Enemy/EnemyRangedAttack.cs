using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedAttack : MonoBehaviour {

    public float timeBetweenAttacks = 5f; //changes by monsters
    public int attackDamage = 150; //changes by monsters
    public float range = 25f;
    public AudioClip fireBall;
    public AudioClip wizardHurt;
    public float playerDistance;
    

    //private variables
    Animator anim;
    Transform playerPosition;
    GameObject player;
    PlayerStats playerStats;
    EnemyStats enemyStats;
    AudioSource wizardAudio;

    
    float timer;
    
    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        //shootableMask = LayerMask.GetMask("Shootable");
        playerStats = player.GetComponent<PlayerStats>();
        playerPosition = player.transform;
        enemyStats = GetComponent<EnemyStats>();
        anim = GetComponent<Animator>();
        wizardAudio = GetComponent<AudioSource>();
        playerDistance = Vector3.Distance(playerPosition.position, transform.position);
    }
	
	// Update is called once per frame
	void Update () {

        playerDistance = Vector3.Distance(playerPosition.position, transform.position);

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && range >= playerDistance && enemyStats.currentHealth > 0 && playerStats.currentHealth>0)
        {
            timer = 0f;
            anim.SetTrigger("playerInRange");
            //Attack();
        }

        if (playerStats.currentHealth <= 0)
        {
            anim.SetBool("PlayerDead", true);
        }

    }

    void Attack() {
        if (playerStats.currentHealth > 0)
        {
            wizardAudio.clip = fireBall;
            wizardAudio.Play();
            wizardAudio.clip = wizardHurt;

            playerStats.TakeDamage(attackDamage);
        }
    }
}
