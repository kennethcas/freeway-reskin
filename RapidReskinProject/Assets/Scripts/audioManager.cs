using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audioManager : MonoBehaviour
{
    AudioSource snd;
    void Start()
    {
        snd = GetComponent<AudioSource>();
        snd.playOnAwake = false;
    }
    private void Update()
    {
        /*if (snd.isPlaying)
        {
            Debug.Log("enemy sound effect is playing");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player1" || col.tag == "player2")
        {
            if (!snd.isPlaying)
            {
                snd.Play();

            }
        }
    }
}
