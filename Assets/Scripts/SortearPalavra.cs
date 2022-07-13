using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortearPalavra : MonoBehaviour
{
    public Sprite[] sprite;
    public int numSprite;
    public Vector3 spriteSize;
    void Start()
    {
        numSprite=Random.Range(0, sprite.Length);
        spriteSize = sprite[numSprite].rect.size;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[numSprite];
        gameObject.GetComponent<BoxCollider>().size = new Vector3(spriteSize.x/100,spriteSize.y/100,0.2f);
        Destroy(gameObject,12);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

}
