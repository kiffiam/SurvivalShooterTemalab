using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {

    
    public int damagePerHit = 0;
    //TODO: Asking the weapon's damage

    public float timeBetweenHits = 0.5f;
    //changes between weapons?


    float timer;
    AudioSource weaponAudio;
    float effectsDisplayTime = 0.2f; //right value?

    private void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        //shootable mask /damageable mask
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenHits && Time.timeScale != 0)
        {
            Hit();
        }

        if (timer >= timeBetweenHits * effectsDisplayTime)
        {
            DisableEffects();
        }
	}

    public void DisableEffects()
    {
       //TODO WAT
    }

    void Hit()
    {
        timer = 0f;

        weaponAudio.Play();
        //TODO: all
    }
}
