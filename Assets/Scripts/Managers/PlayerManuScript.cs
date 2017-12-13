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
    float timer;
    float limit = 5f;
    
	public Text damage_text;
	public Text health_text;

	// Use this for initialization
	void Awake () {
        
        player = GameObject.FindGameObjectWithTag("Player");
		playerStats = player.GetComponent<PlayerStats> ();
		playerMelee = player.GetComponent<PlayerMelee> ();
        
        //points.text = currentPointsToUse.ToString();
    }

    public void Showed()
    {
        points.text = currentPointsToUse.ToString();
		health_text.text = playerStats.startingHealth.ToString();
		damage_text.text = playerMelee.damagePerHit.ToString ();
    }


    // Update is called once per frame
    void Update () {
        PointGiver();
		health_text.text = playerStats.startingHealth.ToString();
		damage_text.text = playerMelee.damagePerHit.ToString ();
	}

	public void AddDamagePoints(){
		if(currentPointsToUse>=1){
			currentPointsToUse -= 1;
			playerMelee.damagePerHit += 5;
		}
		points.text = currentPointsToUse.ToString();
	}

	public void AddHealthPoints(){
		if(currentPointsToUse>=1){
			currentPointsToUse -= 1;
			playerStats.startingHealth+=10;
		}
		points.text = currentPointsToUse.ToString();
	}

    public void BackButtonClicked() {
        Time.timeScale = 1;
    }

    public void PointGiver() {
        timer += Time.deltaTime;
        if (timer > limit) {
            timer = 0f;
            currentPointsToUse++;
            limit += 2f;
        }
        

    }

}
