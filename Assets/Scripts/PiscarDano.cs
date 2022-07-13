using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscarDano : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public IEnumerator PiscaDano()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
