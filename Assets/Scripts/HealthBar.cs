using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float vidaAtual;
    public Slider healthBar;
    public Image fill;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name=="Level1")
        {
            vidaAtual = GameObject.Find("Player").GetComponent<PlayerControllerRunner>().life;
        }
        else
        {
            vidaAtual = GameObject.Find("Player").GetComponent<PlayerController>().life;
        }
        
        healthBar.value = vidaAtual;
        if (vidaAtual>66) {
            fill.color = Color.green;
        }
        else if (vidaAtual>33 && vidaAtual<=66)
        {
            fill.color = Color.yellow;
        }
        else if (vidaAtual<=33)
        {
            fill.color = Color.red;
        }
        if (vidaAtual<=0)
        {
            fill.enabled = false;
        }
        else{
            fill.enabled = true;
        }
    }
}
