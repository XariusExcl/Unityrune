/*
(Attached to the main Camera)
Moves the camera to follow the player (or not)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Transform tr;
    public bool isFollowing = true;

    void Start()
    {
        tr = GetComponent<Transform>();
    }
    
    void Update()
    {
        if(isFollowing)
        {
            tr.position = player.transform.position + new Vector3(0,0,-3f);
        }   // 5AM coding ftw.
    }
}
