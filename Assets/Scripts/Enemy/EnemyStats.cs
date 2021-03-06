﻿using System.Collections;
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
    bool isSinking;

    float timer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        
        capsuleCollider = GetComponent<CapsuleCollider>();

        enemyMeleeAttack=GetComponent<EnemyMeleeAttack>();
        enemyMeleeMovement=GetComponent<EnemyMeleeMovement>();

        currentHealth = startingHealth;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (isSinking)
        {
            if (timer > 4f)
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        enemyAudio.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        ScoreManager.score += scoreValue;

        enemyAudio.clip = deathClip;

        enemyAudio.Play();

        StartSinking();

        //enemyMeleeMovement.enabled = false; 
        //enemyMeleeAttack.enabled = false;
        capsuleCollider.isTrigger = true;
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        timer = 0f;
        Destroy(gameObject, 6f);
    }



}
