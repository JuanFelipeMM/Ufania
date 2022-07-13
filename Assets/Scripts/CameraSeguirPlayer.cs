using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguirPlayer : MonoBehaviour
{
    public Vector3 distancia;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =player.transform.position + distancia;
    }
}
