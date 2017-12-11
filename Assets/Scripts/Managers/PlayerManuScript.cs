using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManuScript : MonoBehaviour {

	 PlayerStats playerStats;
	 PlayerMelee playerMelee;
	 public int currentPointsToUse;
	 public Text points;
     GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		playerStats = player.GetComponent<PlayerStats> ();
		playerMelee = player.GetComponent<PlayerMelee> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamagePoints(){
		if(currentPointsToUse>=1){
			currentPointsToUse -= 1;
			playerMelee.damagePerHit += 2;
		}
		points.text = currentPointsToUse.ToString();
	}

	public void addHealthPoints(){
		if(currentPointsToUse>=1){
			currentPointsToUse -= 1;
			playerStats.currentHealth+=5;
		}
		points.text = currentPointsToUse.ToString();
	}

}
