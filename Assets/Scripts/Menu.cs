using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool isOpen = false;
    
    public Animator animator;

    //public RalseiController ralseiController;

	void Start()
	{
	}
    void Update()
    {
        if (Input.GetButtonDown("Menu")) // Open the menu if the menu key is pressed
        {
            isOpen = !isOpen;
            animator.SetBool("IsOpen", isOpen);
            RalseiController.inMenu = isOpen;
        }


    }
}
