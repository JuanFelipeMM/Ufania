using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitorias : MonoBehaviour
{
    public GameObject vitoria;
    public bool venceu;
    private string level;
    private int quantidadeFrutas=20;
    void Start()
    {
        vitoria.gameObject.SetActive(false);
        Time.timeScale = 1;
        venceu = false;
        level = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        switch(level){
            case "Level1":
                if (Level1Venceu()==true) {
                    Vitoria();
                };break;
            case "Level2":
                if (Level2Venceu()==true)
                {
                    Vitoria();
                }; break;
            case "Level3":
                if (Level3Venceu() == true)
                {
                    Vitoria();
                }; break;
        }
    }

    public void Vitoria()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().Pause();
        vitoria.gameObject.SetActive(true);
        Time.timeScale = 0;
        venceu = true;
    }

    public void AvancarLevel()
    {
        switch (level)
        {
            case "Level1":
                SceneManager.LoadScene("Level2");
                Time.timeScale = 1;
                break;
            case "Level2":
                SceneManager.LoadScene("Level3");
                Time.timeScale = 1;
                break;
            case "Level3":
                SceneManager.LoadScene("FIM");
                Time.timeScale = 1;
                break;
        }      
        Time.timeScale = 1;
    }

    public bool Level1Venceu()
    {
        if ( GetComponent<Timer>().tempo >= 60 && GetComponent<GameOver>().fimJogo==false)
        {
            Debug.Log("Venceu");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level2Venceu()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().contadorColetavel >= quantidadeFrutas && !GetComponent<GameOver>().fimJogo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level3Venceu()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().FIM && !GetComponent<GameOver>().fimJogo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
