using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoestimaStatus : MonoBehaviour
{
    public float speedStatus;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speedStatus = speedStatus = GameObject.Find("Player").GetComponent<PlayerController>().speed;
        if (speedStatus<2)
        { 
            GetComponent<Image>().enabled=true;
        }
        else { GetComponent<Image>().enabled = false; }
    }
}
