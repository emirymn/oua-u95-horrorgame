using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    public AudioSource audio;
    public bool FadeNow;
    public float TimeMultiplier = 5f; //How fast we should fade out.
    void Update()
    {
        if (FadeNow)
        {
            if (audio.volume > 0)
            {
                //The slower we want to fade, the smaller TimeMultiplier would be.
                audio.volume -= Time.deltaTime * TimeMultiplier;
            }
            else
            {
                /*If it is down to 0, we don't have to let the script decrement it anymore.
                Otherwise it would still try to decrement it, which is useless*/
                audio.volume = 0f;
            }
        }
        else
        {
            audio.volume = audio.volume; // Make sure it doesnt change, just in case.
        }
    }

}