using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause;
    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Pause.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
    }
}
