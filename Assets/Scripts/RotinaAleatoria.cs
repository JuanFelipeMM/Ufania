using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotinaAleatoria : MonoBehaviour
{
    public GameObject targetAleatorio;
    void Start()
    {
        targetAleatorio = new GameObject();
        targetAleatorio.transform.parent = gameObject.transform.parent;
        TrocarPosTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.Find("CampoVisaoSphere").GetComponent<CampoDeVisao>().seguir == false)
        {
            gameObject.GetComponent<Enemy>().SetTarget(targetAleatorio.transform) ;
        }
  
    }
    public void TrocarPosTarget()
    {
        float PosicaoZAle = Random.Range(gameObject.transform.position.z - 10, gameObject.transform.position.z + 10);
        float PosicaoXAle = Random.Range(gameObject.transform.position.x - 10, gameObject.transform.position.x + 10);
        targetAleatorio.transform.position = new Vector3(PosicaoXAle, gameObject.transform.position.y, PosicaoZAle);
        Invoke("TrocarPosTarget", 4f);
    }
}
