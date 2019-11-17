/*
(Attached to the main Camera)
Moves the camera to follow the player (or not)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    Transform tr;
    public bool enableX = true;
    public bool enableY = true;

    void Start()
    {
        tr = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(enableX)
        {
            tr.position = new Vector3(player.position.x, tr.position.y, -3f);
        }
        if(enableY)
        {
            tr.position = new Vector3(tr.position.x, player.position.y, -3f);
        }
    }
}
