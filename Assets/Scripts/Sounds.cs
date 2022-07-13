using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sfx;
    public AudioSource soundPlayer;
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TocarSFX(int index)
    {
        soundPlayer.clip = sfx[index];
        soundPlayer.Play();
    }
    public void PararSFX()
    {
        soundPlayer.Pause();
    }
}
