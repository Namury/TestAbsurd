﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailTrigger : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Triggered"); 
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
