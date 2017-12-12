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
    public AudioClip levelUpClip;
    public AudioClip defendingClip;
    public AudioClip hurted;

    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 1f, 1f, 0.1f);

    
    //private variables

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerRanged playerRanged;
    PlayerMelee playerMelee;
    bool isDead;
    bool damaged; //for damaging flashing
    public bool blocking;
    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerRanged = GetComponent<PlayerRanged>();
        playerMelee = GetComponent<PlayerMelee>();
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        healthText.text = "Health: " + startingHealth + "/" + currentHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")) // defending takes effort, so you can't do it while attacking
        {
            blocking = true;
            
        }
        else
        {
            blocking = false;
            
        }
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        
    }

    //Health reduce by the enemy's attack damage
    public void TakeDamage(int amount)
    {
        if (blocking && playerMelee.enemyInRange)
        {
            playerAudio.clip = defendingClip;
            playerAudio.Play();
           
            // play different audio to indicate shield hit instead of damage
        }
        else
        {
            damaged = true;

            currentHealth -= amount;
            playerAudio.clip = hurted;
            playerAudio.Play();

            if (currentHealth <= 0)
            {
                Death();
                currentHealth = 0;
            }
            healthText.text = "Health: " + startingHealth + "/" +  currentHealth; //Convert.ToString(currentHealth);
        }
    }


    //player dies
    void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
       
        playerMelee.enabled = false;
    }
}
