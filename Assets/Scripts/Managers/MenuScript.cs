﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
