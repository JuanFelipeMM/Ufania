using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPalavras : MonoBehaviour
{
    public GameObject palavraPrefab;
    void Start()
    {
        InvokeRepeating("SpawnPalavra",2,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPalavra()
    {
        Instantiate(palavraPrefab, transform.position, transform.rotation);
        
    }
}
