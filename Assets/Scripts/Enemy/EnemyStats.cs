using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int startingHealth = 100; //changes from monster to monster
    public int currentHealth;
    public float sinkSpeed = 2.5f; //do bodies sink instantly or at the end of the wave?
                                   //intanst: suck. End: cpu
    public int scoreValue = 10; //changes from monster to monster //interfaces to avoid code duplication??????!!!!!!
    public AudioClip deathClip;


    EnemyMeleeAttack enemyMeleeAttack;
    EnemyMeleeMovement enemyMeleeMovement;

    Animator anim;
    AudioSource enemyAudio;

    CapsuleCollider capsuleCollider;
    bool isDead = false;
    bool isSinking; //????

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        //hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        enemyMeleeAttack=GetComponent<EnemyMeleeAttack>();
        enemyMeleeMovement=GetComponent<EnemyMeleeMovement>();

        currentHealth = startingHealth;
    }

    
    void Update()
    {
        //needing?
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public bool TakeDamage(int amount) //return true if the hit kills
    {
        if (isDead)
            return false;

        currentHealth -= amount;

        enemyAudio.Play();

        if (currentHealth <= 0)
        {
            Death();
            return true;
        }
        return false;
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;

        enemyAudio.Play();

        enemyMeleeMovement.enabled = false; 
        enemyMeleeAttack.enabled = false;
    }



}
