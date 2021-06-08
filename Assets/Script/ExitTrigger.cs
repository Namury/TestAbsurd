using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awaken");
        Invoke("Exit", 20f);
    }

    void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
