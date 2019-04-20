using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool isOpen = false;
    public static bool enableMenu = true;
    public Animator animator;

    private Component[] buttons;

    void Update()
    {
        if (Input.GetButtonDown("Menu") && enableMenu == true) // Needs something else to be able to be opened only in the overworld
        {
            isOpen = !isOpen;

            animator.SetBool("IsOpen", isOpen);
            RalseiController.inMenu = isOpen;

            
            buttons = GetComponentsInChildren<Button>();

            foreach(Button button in buttons)
            {
                button.interactable = isOpen;
            }
            if (isOpen)
            {
                Button firstButton = GetComponentInChildren<Button>();

                if (firstButton != null)
                {
                    firstButton.Select();
                    firstButton.OnSelect(null);
                }

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
