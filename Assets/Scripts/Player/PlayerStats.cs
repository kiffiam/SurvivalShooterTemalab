using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    //public variables, other scripts need to reach them
    public int startingHealth = 100;
    public int currentHealth;
    public Text healthText;
    public AudioClip deathClip;

    //public Image damageImage;
    //public float flashSpeed = 5f;
    //public Color flashColor = new Color(1f, 1f, 1f, 0.1f);

    //public AudioClip cheer;



    //private variables
    //Text healthText;  // do i need this? instead in Healt Manager which writes it out
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerMelee playerMelee;
    bool isDead;
    bool damaged; //for damaging flashing



    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
        playerMelee = GetComponent<PlayerMelee>();
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            //TODO: what would happen if the player gets hurt
        }
        else
        {
            //TODO: hurting effect goes away
        }
        damaged = false;
    }

    //Health reduce by the enemy's attack damage
    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthText.text = Convert.ToString(currentHealth);

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    //player dies
    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        anim.SetTrigger("Die");

        //TODO: highscore name entering etc,,???

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
}
