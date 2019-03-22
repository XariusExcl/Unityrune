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
        if (Input.GetButtonDown("Menu")) // Needs something else to be able to be opened only in the overworld
        {
            isOpen = !isOpen;

            animator.SetBool("IsOpen", isOpen);
            RalseiController.inMenu = isOpen;

            foreach(Transform child in transform)
            {
                child.GetComponent<Button>().interactable = isOpen;
            }
            if (isOpen)
            {
                Button firstButton = gameObject.GetComponentInChildren<Button>();
                firstButton.Select();
                firstButton.OnSelect(null);
            }
        }
    }
}
