using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    private Animator anim;
    Vector3 direction;
    public bool seguir=false;
    public float tempoEsperaAtaque;
    public int enemyLife;
    public int damage;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        tempoEsperaAtaque = Time.time;
    }

    
    void Update()
    {

        if (seguir) { target = GameObject.Find("Player").transform; }
        else { seguir = transform.parent.Find("CampoVisaoSphere").GetComponent<CampoDeVisao>().seguir; }
        SetTarget(target);
        SetDirection();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            DarDano();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            seguir = true;
            GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(4);
        }
    }
    void DarDano()
    {
        if (Time.time >= tempoEsperaAtaque)
        {
            tempoEsperaAtaque = Time.time + 2;
            GameObject.Find("Player").GetComponent<PlayerController>().life -= damage;
            GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(0);
            StartCoroutine(GameObject.Find("Player").GetComponent<PiscarDano>().PiscaDano());
        }
    }

    public void PerderVida()
    {
        enemyLife -= 1;
    }
    public void SetTarget(Transform newtarget)
    {
        target = newtarget;
        if (target != null)
        {

            agent.SetDestination(target.position);
            
        }
        else { return; }
    }
    void SetDirection()
    {
        direction = agent.desiredVelocity;
        if (target.transform.position.z<transform.position.z) {
            anim.SetBool("Abaixo", true);
            anim.SetBool("Acima", false);
            anim.SetFloat("PosX",direction.magnitude);
        }
        if (target.transform.position.z > transform.position.z)
        {
            anim.SetBool("Acima", true);
            anim.SetBool("Abaixo", false);
            anim.SetFloat("PosX", direction.magnitude);
        }
        if((target.transform.position.x - transform.position.x) >= 1.5f)
        {
            anim.SetBool("Acima", false);
            anim.SetBool("Abaixo", false);
            anim.SetBool("Esquerda", false);
            anim.SetBool("Direita", true);
            anim.SetFloat("PosX", direction.magnitude);
        }
        if ((target.transform.position.x - transform.position.x) <= -1.5f)
        {
            anim.SetBool("Acima", false);
            anim.SetBool("Abaixo", false);
            anim.SetBool("Direita", false);
            anim.SetBool("Esquerda", true);
            anim.SetFloat("PosX", direction.magnitude);

        }

    }
}
