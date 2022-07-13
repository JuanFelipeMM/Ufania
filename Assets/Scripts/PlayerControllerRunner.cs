using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRunner : MonoBehaviour
{
    public float life = 100f;
    public float maxLife = 100f;
    public float horizontalLado;
    public float speed = 2;
    public Animator animator;
    Rigidbody playerRb;
    private SpriteRenderer sprite;
    public float jumpForce = 10;
    public float fallForce = 0.5f;
    public float gravityModifier;
    public bool isOnGround;
    public bool fimJogo = false;
    public float xRange = 2.0f;
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
        
        horizontalLado = Input.GetAxis("Horizontal");
        //movimento
        transform.Translate(Vector3.right * horizontalLado * speed * Time.deltaTime);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); ;
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); ;
        }

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
        if (life <= 0)
        {
            life = 0;
            fimJogo = true;
        }
        else
        {
            fimJogo = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Palavra"))
        {
            life -= 34;
            Destroy(collision.gameObject);
            GameObject.Find("SoundFX").GetComponent<Sounds>().TocarSFX(0);
            StartCoroutine(gameObject.GetComponent<PiscarDano>().PiscaDano());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Palavra")) {

            sprite.color = Color.white;
        }           
    }

}
