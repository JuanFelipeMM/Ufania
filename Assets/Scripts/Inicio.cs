using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    public Transform inicio;
    public bool iniciado;
    void Start()
    {
        GameObject.Find("Music").GetComponent<AudioSource>().Play();
        inicio.gameObject.SetActive(true);
        Time.timeScale = 0;
        iniciado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (iniciado==false)
        {
            inicio.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            inicio.gameObject.SetActive(false);
        }
    }

    public void Iniciar()
    {  
        inicio.gameObject.SetActive(false);
        Time.timeScale = 1;
        iniciado = true;
    }
}
