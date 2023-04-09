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
    [Header("Lock On Bools")]
    public List<bool> lockDoors;
    private bool gardenLock = false;
    private bool priFloorLock = false;
    private bool duoFloorLock = false;
    private bool triFloorLock = false;
    private bool tetFloorLock = false;
    private bool penFloorLock = false;

    void Awake()
    {
        instance = this;

        lockDoors.Add(gardenLock);
        lockDoors.Add(priFloorLock);
        lockDoors.Add(duoFloorLock);
        lockDoors.Add(triFloorLock);
        lockDoors.Add(tetFloorLock);
        lockDoors.Add(penFloorLock);
        
        audioSource.PlayOneShot(backMusicList[Random.Range(0, backMusicList.Count - 1)]);
    }

}
