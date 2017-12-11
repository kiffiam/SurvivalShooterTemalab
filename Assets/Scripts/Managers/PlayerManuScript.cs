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
	void Awake () {

        player = GameObject.FindGameObjectWithTag("Player");
		playerStats = player.GetComponent<PlayerStats> ();
		playerMelee = player.GetComponent<PlayerMelee> ();
        //points.text = currentPointsToUse.ToString();
    }

    private void OnBecameVisible()
    {
        points.text = currentPointsToUse.ToString();
    }


    // Update is called once per frame
    void Update () {
		
	}

	public void AddDamagePoints(){
		if(currentPointsToUse>=1){
			currentPointsToUse -= 1;
			playerMelee.damagePerHit += 2;
		}
		points.text = currentPointsToUse.ToString();
	}

	public void AddHealthPoints(){
		if(currentPointsToUse>=1){
			currentPointsToUse -= 1;
			playerStats.startingHealth+=5;
		}
		points.text = currentPointsToUse.ToString();
	}

    public void BackButtonClicked() {
        Time.timeScale = 1;
    }

}
