using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            Destroy(transform.parent.gameObject, 0.1f);
        }
    }
}
