using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
namespace EvolveGames
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] GameObject ghost;
        bool ghostIsMoved = false;
        [SerializeField] GameObject player;
        Animator anim;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("GameController"))
            {
                // player = other.gameObject;
                anim = ghost.GetComponent<Animator>();
                player.GetComponent<PlayerController>().enabled = false;
                player.transform.GetChild(0).GetChild(0).GetComponent<MovementEffects>().enabled = false;
                player.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<HeadBob>().enabled = false;
                player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<HandsHolder>().enabled = false;
                player.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<HandsSmooth>().enabled = false;
                ghost.SetActive(true);
                GameManager.instance.flashlightLight.spotAngle = 80f;
                player.transform.DOLocalRotate(new Vector3(0, 250, 0), 1f).OnComplete(() =>
                {
                    ghost.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
                    anim.SetFloat("Speed", 1f);
                    ghostIsMoved = true;

                });
                /*    other.transform.DOLocalRotate(new Vector3(0, 250, 0), 1f).OnComplete(() =>
                    {
                        StartCoroutine(CameraGoBack(other.gameObject));
                    });*/
            }
        }

        private void Update()
        {
                if (ghostIsMoved && ghost.GetComponent<NavMeshAgent>().remainingDistance < 1f)
                {
                    UIController.instance.blackScreen.SetActive(true);
                }
        }
        IEnumerator CameraGoBack(GameObject other)
        {
            yield return new WaitForSeconds(3f);
            other.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f);
        }
        void FinishScene(GameObject other)
        {

        }
        /*  IEnumerator CameraGoBack(GameObject other)
          {
              yield return new WaitForSeconds(3f);
              other.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f);
          }*/
    }
}
