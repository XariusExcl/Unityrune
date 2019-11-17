using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string level;
    public string doorLetter;
    public enum Direction
    {
        up, left, down, right
    }
    public Direction direction;
    GameObject player;
    PlayerController playerpc;
    LevelChanger lc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerpc = player.GetComponent<PlayerController>();
        if(player == null) { Debug.Log("[Door]" + gameObject.name + " : Player not found!"); }
        lc = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
        if(player == null) { Debug.Log("[Door]" + gameObject.name + " : Level Changer not found!"); }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerpc.lastDoor = doorLetter;
            playerpc.walking = true;
            lc.FadeToLevel(level);
        }
    }   
}
