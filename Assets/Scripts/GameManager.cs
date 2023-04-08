using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("SFX Short FX")]
    public static GameManager instance;
    public List<AudioClip> shortEffect;
    public List<AudioClip> backMusicList;
    [Space]
    [Header("AudioSource")]
    public AudioSource audioSource;
    public AudioSource sfxSource;
    void Awake()
    {
        instance = this;
        audioSource.PlayOneShot(backMusicList[Random.Range(0, backMusicList.Count - 1)]);
    }

}
