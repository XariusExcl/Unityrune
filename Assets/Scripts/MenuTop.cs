/* 
(Attached to MenuTop)
The logic for the top Menu, which has buttons to open certain menus.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTop : MonoBehaviour
{
    [HideInInspector]
    public static bool isOpen = false;
    public static bool enableMenu = true;
    Animator anim;
    private Component[] buttons;

    public bool langIsJapanese;
    public SpriteRenderer description;
    public Sprite[] menuDesc;

    int jap;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (langIsJapanese)
        {
            jap = 5;
        } else { jap = 0;}

        if (Input.GetButtonDown("Menu") && enableMenu == true)
        {
            isOpen = !isOpen;

            anim.SetBool("IsOpen", isOpen);

            buttons = GetComponentsInChildren<Button>();

            foreach(Button button in buttons)
            {
                button.interactable = isOpen;
            }
            if (isOpen)
            {
                Button firstButton = GetComponentInChildren<Button>();

                firstButton.Select();
                firstButton.OnSelect(null);
            }
        }
    }
    public void HoverItems()
    {
        description.sprite = menuDesc[0 + jap];
    }
    public void SelectItems()
    {
        Debug.Log("Selected Items!");
    }

    public void HoverEquipment()
    {
        description.sprite = menuDesc[1 + jap];
    }
    public void SelectEquipment()
    {
        Debug.Log("Selected Equipment!");
    }

    public void HoverStats()
    {
        description.sprite = menuDesc[3 + jap];
    }
    public void SelectStats()
    {
        Debug.Log("Selected Stats!");
    }

    public void HoverSettings()
    {
        description.sprite = menuDesc[4 + jap];
    }
    public void SelectSettings()
    {
        Debug.Log("Selected Settings!");
    }
}
