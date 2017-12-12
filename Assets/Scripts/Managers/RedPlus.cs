using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RedPlus : MonoBehaviour {

    public int healthValue = 100;


    Rigidbody rigidbody;
    Animator anim;
    AudioSource redPlusAudio;
    PlayerStats playerStats;
    CapsuleCollider collider;
    Renderer rend;
   

    // Use this for initialization
    void Awake () {

        anim = GetComponent<Animator>();
        redPlusAudio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        rend = GetComponent<Renderer>();
        collider = GetComponent<CapsuleCollider>();

        Destroy(gameObject, 18f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !other.isTrigger)
        {
            redPlusAudio.Play();
            rend.enabled = false;
            collider.enabled = false;
            if (playerStats.currentHealth + healthValue <= playerStats.startingHealth)
            {
                playerStats.currentHealth += healthValue;
            }
            else {
                playerStats.currentHealth = playerStats.startingHealth;
            }
            
            playerStats.healthText.text = "Health: " + playerStats.startingHealth + "/" +  playerStats.currentHealth;

            //particles effect maybe

            Destroy(gameObject, redPlusAudio.clip.length);
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        
    }*/
}
