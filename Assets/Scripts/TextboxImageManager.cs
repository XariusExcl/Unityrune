using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxImageManager : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private string spriteNames = "Sprites/Ralsei/Face";
    private Sprite[] faces;
    private int spriteIndex = 1;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        faces = Resources.LoadAll<Sprite>("Sprites/Ralsei/Face");
        Debug.Log("Loaded " + faces.Length + " Faces!");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteIndex++;
            Debug.Log("Displaying Sprite version #" + spriteIndex);
        }
        spriteRenderer.sprite = faces[spriteIndex];
    }

}