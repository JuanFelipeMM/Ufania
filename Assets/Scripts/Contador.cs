using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public float quantidade;
    void Start()
    {
        GetComponent<Text>().text = "Frutas: " + quantidade;
    }

    // Update is called once per frame
    void Update()
    {
        quantidade = GameObject.Find("Player").GetComponent<PlayerController>().contadorColetavel;
        GetComponent<Text>().text = "Frutas: " + quantidade;
    }
}
