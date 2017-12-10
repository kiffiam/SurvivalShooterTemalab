using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlusSpawnManager : MonoBehaviour {

    public PlayerStats playerHealth;
    public GameObject redPlus;
    public float spawnTime = 7f;
    public Transform[] spawnPoints;
    //public bool[] spawnPointOccupied;

    // Use this for initialization
    void Start () {
        //"spawn()" repeating spawntimes
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Spawn () {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(redPlus, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        

    }
}
