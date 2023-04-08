using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    
    
    bool isPlayed;
    private void Awake()
    {
        isPlayed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isPlayed)
        {
            GameManager.instance.audioSource.PlayOneShot(GameManager.instance.shortEffect[Random.Range(0, GameManager.instance.shortEffect.Count - 1)]);
            isPlayed = true;
        }
    }
}
