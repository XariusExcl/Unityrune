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
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
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

    public void SelectItems()
    {
        Debug.Log("Selected Items!");
    }

    public void SelectEquipment()
    {
        Debug.Log("Selected Equipment!");
    }

    public void SelectStats()
    {
        Debug.Log("Selected Stats!");
    }

    public void SelectSettings()
    {
        Debug.Log("Selected Settings!");
    }
}
