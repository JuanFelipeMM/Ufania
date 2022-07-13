using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public GameObject tiroPrefab;
    private Vector3 posInicial;
    public Vector3 offSet = new Vector3(0, 0, 3);
    public float rotacao;
    private Quaternion rotQua;
    public float speed = 10;
    private Animator animator;
    public float tempoTiro;
    public float espacoTempoTiro=0.2f;
    // Start is called before the first frame update
    void Start()
    {
        tempoTiro = Time.time;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.time>= tempoTiro+espacoTempoTiro) {
                tempoTiro = Time.time;
                //Posicionar tiro
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_de_Costas") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Costas"))
                {
                    offSet.Set(-0.175f, -0.075f, 0.2f);
                    rotacao = 0;
                    rotQua = Quaternion.Euler(0, rotacao, 0);
                    posInicial = transform.position + offSet;
                    Instantiate(tiroPrefab.gameObject, posInicial, rotQua);
                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_Frente") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Frente"))
                {
                    offSet.Set(0.175f, -0.075f, -0.2f);
                    rotacao = 180;
                    rotQua = Quaternion.Euler(0, rotacao, 0);
                    posInicial = transform.position + offSet;
                    Instantiate(tiroPrefab.gameObject, posInicial, rotQua);

                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_Esquerda") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Esquerda"))
                {
                    offSet.Set(0, -0.070f, -0.05f);
                    rotacao = 270;
                    rotQua = Quaternion.Euler(0, rotacao, 0);
                    posInicial = transform.position + offSet;
                    Instantiate(tiroPrefab.gameObject, posInicial, rotQua);
                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_Direita") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Direita"))
                {
                    offSet.Set(0, -0.070f, -0.05f);
                    rotacao = 90;
                    rotQua = Quaternion.Euler(0, rotacao, 0);
                    posInicial = transform.position + offSet;
                    Instantiate(tiroPrefab.gameObject, posInicial, rotQua);
                }
                GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(1);
            }
            
        }


    }

}
