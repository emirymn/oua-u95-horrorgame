using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedUIShow : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            GetComponent<TextMeshPro>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameController"))
        {
            GetComponent<TextMeshPro>().enabled = false;
        }
    }
}
