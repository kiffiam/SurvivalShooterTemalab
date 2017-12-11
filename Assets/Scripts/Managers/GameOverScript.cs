using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
				saveScore();
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
		}
	}

	public void saveScore(){
		string path = "Assets/scores.txt";
		StreamWriter writer = new StreamWriter(path, true);
		writer.WriteLine(MenuScript.playerName+"\t"+ScoreManager.score);
		writer.Close();
	}

}
