using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;
    public bool pausado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale=1;
                pausado = false;
                GameObject.Find("Music").GetComponent<AudioSource>().Play();
            }
            else
            {
                GameObject.Find("Music").GetComponent<AudioSource>().Pause();
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                pausado = true;
            }
        }
    }

    public void ResumirJogo()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        pausado = false;
    }
}
