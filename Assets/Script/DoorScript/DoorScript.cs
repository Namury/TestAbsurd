using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorScript : MonoBehaviour
{
    AudioSource audioSrc;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("OpenDoor");
        Invoke("playSound", 0.5f);
    }
    void OnTriggerExit(Collider other)
    {
        anim.enabled = true;
    }
    void pauseAnimationEvent()
    {
        anim.enabled = false;
    }

    void playSound()
    {
        audioSrc.Play();
    }
}
