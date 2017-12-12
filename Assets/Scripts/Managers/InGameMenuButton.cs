using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuButton : MonoBehaviour {

    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void Clicked () {
        Time.timeScale = 0;
        audioSource.Play();
    }
}
