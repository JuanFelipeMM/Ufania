using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text texto;
    public float tempo=0;
    void Start()
    {
        tempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;
        texto.text = "Tempo: " + ((int)tempo);
    }
}
