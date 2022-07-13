using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Transform gameOver;
    public GameObject player;
    public bool fimJogo;
    public bool pausado;
    public bool iniciado;
    public bool vitoria;
    void Start()
    {
       player= GameObject.Find("Player");
       pausado = GameObject.Find("Main Camera").GetComponent<PauseMenu>().pausado;
       iniciado = GameObject.Find("Main Camera").GetComponent<Inicio>().iniciado;
       vitoria= GameObject.Find("Main Camera").GetComponent<Vitorias>().venceu;
    }

    // Update is called once per frame
    void Update()
    {
        pausado = GameObject.Find("Main Camera").GetComponent<PauseMenu>().pausado;
        iniciado = GameObject.Find("Main Camera").GetComponent<Inicio>().iniciado;
        vitoria = GameObject.Find("Main Camera").GetComponent<Vitorias>().venceu;

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            fimJogo = player.GetComponent<PlayerControllerRunner>().fimJogo;
        }
        else
        {
            fimJogo = player.GetComponent<PlayerController>().fimJogo;
        }

            
        if (fimJogo) {
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;  
        }
        else if(!fimJogo && !pausado && iniciado && !vitoria)
        {
            Time.timeScale = 1;
        }
    }

    public void TentarDeNovo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Sair()
    {
        Application.Quit();
    }
     public void irMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
