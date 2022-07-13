using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetComponent<Enemy>().PerderVida();
            StartCoroutine(gameObject.GetComponent<PiscarDano>().PiscaDano());
            Destroy(other.gameObject);
            if (GetComponent<Enemy>().enemyLife<=0)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}
