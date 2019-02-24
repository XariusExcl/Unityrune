using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool isOpen = false;
    
    public Animator animator;
    void Update()
    {
        if (Input.GetButtonDown("Menu")) // Open the menu if the menu key is pressed
        {
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);
            RalseiController.inMenu = isOpen;
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(isOpen);
            }
            // need to highlight the first button
        }
    }
}
