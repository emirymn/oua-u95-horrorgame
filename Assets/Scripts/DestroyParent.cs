using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log(other.name);
            Destroy(other.gameObject.transform.parent.gameObject, 0.1f);
        }
    }
}
