using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour {

    
    public int damagePerHit = 20;

    public float timeBetweenHits = 0.5f;


    float timer;
    AudioSource weaponAudio;
    PlayerStats playerStats;
    EnemyStats enemyStats;
    GameObject[] enemy;
    List<EnemyStats> enemiesInRange;


    bool enemyInRange;

    private void Awake()
    {
        weaponAudio = GetComponent<AudioSource>();
        //shootable mask /damageable mask
        
        
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");

        //enemyStats = enemy.GetComponent<EnemyStats>();

        enemyInRange = false;
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenHits && Time.timeScale != 0 && enemyInRange) //enemiesInRange.Count>0
        {
            Hit();
        }

        
	}
    public bool getInRange()
    {
        return enemyInRange;
        //return enemiesInRange.Count; int
    }

    public void DisableEffects()
    {
       //TODO WAT
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Enemy" && !other.isTrigger)
        {
            enemyInRange = false;
            //enemiesInRange.Remove(other.GetComponent<EnemyStats>());
        }
    }

    //enemy in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !other.isTrigger)
        {
            //enemiesInRange.Add(other.GetComponent<EnemyStats>());
            //enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemyStats = other.GetComponent<EnemyStats>();

            enemyInRange = true;
        }
    }

    void Hit()
    {
        timer = 0f;

        if (enemyStats.currentHealth > 0)
        {
            enemyStats.TakeDamage(damagePerHit);
            /*foreach (EnemyStats enemy in enemiesInRange)
            {
                enemy.TakeDamage(damagePerHit);
            }*/
        }
        
    }
}
