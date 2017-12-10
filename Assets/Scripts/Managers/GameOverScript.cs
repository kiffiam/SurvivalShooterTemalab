using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

	public PlayerStats player;
	Animator anim;

	float delay = 5f;
	float restartTimer;

	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.currentHealth <= 0) {
			anim.SetTrigger ("GameOverTrigger");
			restartTimer += Time.deltaTime;

			if (restartTimer >= delay) {
				Application.LoadLevel (0);
			}
		}
	}
}
