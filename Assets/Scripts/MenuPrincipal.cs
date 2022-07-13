using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Sair()
    {
        Application.Quit();
    }
    public void Iniciar()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("FIM");
    }
}
