using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] float duration;
    IEnumerator Start()
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("SampleScene");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
