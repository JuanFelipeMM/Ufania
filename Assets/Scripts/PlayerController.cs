using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float life = 100f;
    public float maxLife = 100f;
    public float horizontalFrente;
    public float horizontalLado;
    public float speed = 2;
    public Animator animator;
    Rigidbody playerRb;
    private SpriteRenderer sprite;
    public float jumpForce = 10;
    public float fallForce = 0.5f;
    public float gravityModifier;
    public bool isOnGround;
    public int contadorColetavel=0;
    public bool fimJogo=false;
    public bool FIM=false;
    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) {
            life = 0;
            fimJogo = true; 
        }
        else
        {
            fimJogo = false;
        }
        horizontalFrente = Input.GetAxis("Vertical");
        horizontalLado = Input.GetAxis("Horizontal");

        //Pulo
        if (Input.GetKeyUp(KeyCode.Space) && isOnGround == false)
        {
            Vector3 velocidade = playerRb.velocity;
            velocidade.y *= fallForce;
            playerRb.velocity = velocidade;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(3);
            isOnGround = false;
        }
        //movimento
        transform.Translate(Vector3.forward * horizontalFrente * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalLado * speed * Time.deltaTime);

        //Prevenir animações mudarem freneticamente se apertar dois botões ao mesmo tempo
        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
        {
            horizontalFrente = 0;
            horizontalLado = 0;
        }

        animator.SetInteger("Parado_Frente", (int)horizontalFrente);
        animator.SetInteger("Parado_Lado", (int)horizontalLado);
        animator.SetFloat("Horizontal_Frente", horizontalFrente);
        animator.SetFloat("Horizontal_Lado", horizontalLado);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag){
            case "Maca":
                Destroy(other.gameObject);
                contadorColetavel += 1;
                AumentarVida(20);
                GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(2);
                break;
            case "Laranja":
                Destroy(other.gameObject);
                contadorColetavel += 1;
                AumentarVida(30);
                GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(2);
                break;
            case "Banana":
                Destroy(other.gameObject);
                contadorColetavel += 1;
                AumentarVida(40);
                GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(2);
                break;
            case "Abobora":
                Destroy(other.gameObject);
                contadorColetavel += 1;
                AumentarVida(50);
                GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(2);
                break;
            case "ArqueInimigo":
                life=0;
                GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(0);
                break;
            case "FIM":
                FIM = true;
                break;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            sprite.color = Color.white;
        }
    }
    public void AumentarVida(float quantidade)
    {
        float aux=life;
        aux += quantidade;
        if (aux>100)
        {
            life = maxLife;
        }
        else { life += quantidade; }
    }

    
}
