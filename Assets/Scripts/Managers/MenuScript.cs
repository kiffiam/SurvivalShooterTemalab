using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    AudioSource source;
	//public PlayerStats player;
	public Text text;
	public static string playerName;
	
    public void Awake()
    {
        source = GetComponentInChildren<AudioSource>();
    }
    public void Play()
    {
		//player = GetComponent<PlayerStats> ();
		playerName = text.text.ToString();
        source.Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

	public void HighScore()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(2);
	}
	

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
