using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lentidao : MonoBehaviour
{
    public float speedOriginal;
    public float slowSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Palavra")
        {
            DiminuirSpeed(slowSpeed);
            Invoke("VoltarOriginalSpeed",8);
        }
    }
    void VoltarOriginalSpeed()
    {
        GetComponent<PlayerController>().speed = speedOriginal;
    }

    void DiminuirSpeed(float slowspeed)
    {
        if (GetComponent<PlayerController>().speed <= 0)
        {
            GetComponent<PlayerController>().speed = 0;          
        }
        else
        {
            GetComponent<PlayerController>().speed -= slowspeed;
        }
    }
}
