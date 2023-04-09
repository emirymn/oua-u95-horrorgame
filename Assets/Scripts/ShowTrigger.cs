using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrigger : MonoBehaviour
{
    bool isPlayed;
    [SerializeField] GameObject lightGo, ghost;
    private void Awake()
    {
        isPlayed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController") && !isPlayed)
        {
            isPlayed = true;
            StartCoroutine(ScaryAction());
        }
    }
    IEnumerator ScaryAction()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.audioSource.PlayOneShot(GameManager.instance.shortEffect[9]);
        ghost.gameObject.SetActive(true);
        if (lightGo != null)
            lightGo.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        if (lightGo != null)
            lightGo.gameObject.SetActive(false);
        ghost.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        if (lightGo != null)
            lightGo.gameObject.SetActive(true);
        ghost.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (lightGo != null)
            lightGo.gameObject.SetActive(false);
        ghost.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        if (lightGo != null)
            lightGo.gameObject.SetActive(true);
        ghost.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        ghost.gameObject.SetActive(false);
        if (lightGo != null)
            lightGo.gameObject.SetActive(false);
    }
}
