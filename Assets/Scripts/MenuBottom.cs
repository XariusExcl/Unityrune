using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBottom : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        animator.SetBool("IsOpen", MenuTop.isOpen);
    }
}
