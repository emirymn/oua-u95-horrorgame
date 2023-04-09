using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.transform.gameObject.CompareTag("Item"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.instance.lockDoors[1] = true;
                Destroy(hit.transform.gameObject, 0.1f);
            }
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }
        else
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }
}
