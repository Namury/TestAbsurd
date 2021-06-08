using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public float restartDelay = 1f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win"); 
        Invoke("Win", restartDelay);
    }

    // Update is called once per frame
    void Win()
    {
        SceneManager.LoadScene("WinScene");
        
    }

    void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

