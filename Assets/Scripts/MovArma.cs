using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovArma : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public Vector3 posInicial;
    public Vector3 offSet;
    public float rotacao;
    public Quaternion rotQua;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animator = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_de_Costas") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Costas"))
        {
            offSet.Set(-0.175f, -0.109f, 0.1f);
            rotacao = 90;
            rotQua = Quaternion.Euler(90, 0, rotacao);
            posInicial = player.transform.position + offSet;
            transform.position = posInicial;
            transform.rotation = rotQua;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_Frente") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Frente"))
        {
            offSet.Set(0.175f, -0.109f, -0.1f);
            rotacao = 270;
            rotQua = Quaternion.Euler(90, 0, rotacao);
            posInicial = player.transform.position + offSet;
            transform.position = posInicial;
            transform.rotation = rotQua;

        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_Esquerda") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Esquerda"))
        {
            offSet.Set(0.100f, -0.100f, -0.01f);
            rotacao = 180;
            rotQua = Quaternion.Euler(90, 0, rotacao);
            posInicial = player.transform.position + offSet;
            transform.position = posInicial;
            transform.rotation = rotQua;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Andando_Direita") || animator.GetCurrentAnimatorStateInfo(0).IsName("Parado_Direita"))
        {
            offSet.Set(-0.100f, -0.100f, -0.01f);
            rotacao = 0;
            rotQua = Quaternion.Euler(90, 0, rotacao);
            posInicial = player.transform.position + offSet;
            transform.position = posInicial;
            transform.rotation = rotQua;
        }
    }
}
