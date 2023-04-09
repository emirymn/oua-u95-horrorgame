using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraOrigin : MonoBehaviour
{
    Camera cam;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (hit.transform.gameObject.CompareTag("Item"))
                {
                    MissionTextUpdate(hit);
                    StartCoroutine(UIController.instance.MissionShow());
                    GameManager.instance.lockDoors[hit.transform.gameObject.GetComponent<Key>().numberOf] = true;
                    UIController.instance.newItemNameText.text = hit.transform.gameObject.name + "";
                    StartCoroutine(UIController.instance.KeyNameShow());
                    UIController.instance.KeyImageFadeOpen();
                    Destroy(hit.transform.gameObject, 0.1f);
                }

            }
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }

    void MissionTextUpdate(RaycastHit hit)
    {
        UIController.instance.MissionText.text = hit.transform.GetComponent<Key>().missionText;
    }
}
