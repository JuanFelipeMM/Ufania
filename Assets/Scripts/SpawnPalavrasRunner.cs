using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPalavrasRunner : MonoBehaviour
{
    public GameObject palavraPrefab;
    private float tempoAleatorio;
    public Vector3 posXAle= new Vector3(0,0,0);
    void Start()
    {
        tempoAleatorio = Random.Range(0.5f, 2f);
        Invoke("SpawnPalavra", 4);
    }
    void Update()
    {

    }
    public void SpawnPalavra()
    {
        if (GameObject.Find("Main Camera").GetComponent<Timer>().tempo <= 30)
        {
            tempoAleatorio = Random.Range(0.5f, 2f);
        }
        else
        {
            tempoAleatorio = Random.Range(0.5f, 1f);
        }
        posXAle.x = Random.Range(-1.5f,1.5f);
        

        Instantiate(palavraPrefab, transform.position+posXAle, transform.rotation);
        Invoke("SpawnPalavra", tempoAleatorio);
    }
}
