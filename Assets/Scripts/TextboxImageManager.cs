using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxImageManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    Sprite faceSprite;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void DisplayImage(string faceName)
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        faceSprite = Resources.Load<Sprite>("Sprites/Faces/" + faceName);
        spriteRenderer.sprite = faceSprite;
    }
        


}