using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RunTrigger : MonoBehaviour
{
    bool isPlayed;
    [SerializeField] GameObject ghost;
    [SerializeField] Transform targetPos;
    Animator anim;
    NavMeshAgent agent_;
    private void Awake()
    {
        isPlayed = false;
        agent_ = ghost.transform.GetChild(0).GetComponent<NavMeshAgent>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController") && !isPlayed)
        {
            isPlayed = true;
            GameManager.instance.audioSource.PlayOneShot(GameManager.instance.shortEffect[Random.Range(0, GameManager.instance.shortEffect.Count - 1)]);
            agent_.SetDestination(targetPos.position);
            anim.SetFloat("Speed", 1f);
        }
    }
}
