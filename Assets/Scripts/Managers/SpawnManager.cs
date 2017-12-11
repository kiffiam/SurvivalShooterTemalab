using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {



    public PlayerStats playerHealth;
    public GameObject spawnAble;
    public float spawnTime;
    public Transform[] spawnPoints;
    
    // Use this for initialization
    void Awake () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	
	void Spawn () {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(spawnAble, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);


    }
}
