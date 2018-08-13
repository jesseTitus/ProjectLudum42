using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideShow : MonoBehaviour {

    public Sprite[] cardSprites;

    SpriteRenderer spriteRenderer;
    int cardShown;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        cardShown++;
        if (cardShown >= cardSprites.Length) cardShown = 0;
        spriteRenderer.sprite = cardSprites[cardShown];
    }
}
