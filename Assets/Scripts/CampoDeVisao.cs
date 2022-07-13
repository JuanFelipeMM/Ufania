using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDeVisao : MonoBehaviour
{
    public bool seguir=false;
    private string nomeIrmao;
    // Start is called before the first frame update
    void Start()
    {
        seguir = false;
        nomeIrmao = transform.parent.GetChild(0).name;
    }

    // Update is called once per frame
    void Update()
    {
        seguir = RetornaSeguir();
        transform.position = transform.parent.Find(nomeIrmao).transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            seguir = true;
        }
    }
    public bool RetornaSeguir()
    {
        return seguir;
    }
}
