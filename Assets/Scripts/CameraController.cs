﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform tr;
    public bool isFollowing = true;

    void Update()
    {
        if(isFollowing)
        {
            tr.position = player.transform.position + new Vector3(0,0,-15f);
        }   // 5AM coding ftw.
    }
}
