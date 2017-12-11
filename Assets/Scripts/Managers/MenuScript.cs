using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    AudioSource source;
    public void Awake()
    {
        source = GetComponentInChildren<AudioSource>();
    }
    public void Play()
    {
        source.Play();
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
