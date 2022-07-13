using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarAproximacao : MonoBehaviour
{
    public Transform alert;
    public Transform evil;
    public bool perto;
    public float distancia;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (evil.position.y>=distancia)
        {
            alert.gameObject.SetActive(true);
            perto = true;
        }
        else
        {
            alert.gameObject.SetActive(false);
            perto = false;
        }
    }
}
