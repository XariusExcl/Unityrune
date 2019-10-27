using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string level;
    BoxCollider2D player;
    LevelChanger lc;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        if(player == null) {Debug.Log("Door : Player's BoxCollider2D not found!");}
        lc = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
        if(player == null) {Debug.Log("Door : Level Changer not found!");}
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col == player) {lc.FadeToLevel(level); }
    }   
}
