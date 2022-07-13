using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawn : MonoBehaviour
{
    private Vector3 posLimite = new Vector3(0, 0, -47.44f) ;
    private Vector3 posReposicao = new Vector3(0,0,0);
    public GameObject primeiro;
    public GameObject segundo;
    public GameObject terceiro;
    private GameObject aux;
    public float distancia;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (primeiro.transform.position.z<=posLimite.z)
        {
            aux = primeiro;
            primeiro = segundo;
            segundo = terceiro;
            terceiro = aux;
            
        }
        terceiro.transform.position = primeiro.transform.position + new Vector3(0, 0, distancia);
        terceiro.transform.position = segundo.transform.position + new Vector3(0, 0, distancia);
    }
}
