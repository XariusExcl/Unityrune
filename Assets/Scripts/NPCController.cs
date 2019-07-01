/*
(Attached to a player-following NPC)
Follows the main Player.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Animator anim;
    GameObject playerGo;
    Vector3 playerPos;
    Vector3 playerLastPos;
    Vector3 npcPos;
    Vector3 npcLastPos;
    Queue<Vector3> playerPositions = new Queue<Vector3>();
    int size = 15; // the follow "distance" (more like the latency of follow)

    void Start()
    {
        playerGo = GameObject.FindWithTag("Player");
        playerPos = playerGo.transform.position;
        gameObject.GetComponent<Transform>().position = playerPos + new Vector3(-0.30f, 0, 0);

        anim = GetComponent<Animator>();

        float i;
        for (i = -0.28f; i <= 0; i += 0.02f)
        {
            Enqueue(playerPos + new Vector3(i, 0, 0));
        }
    }

    void FixedUpdate()
    {
        playerPos = playerGo.transform.position;
        npcPos = gameObject.GetComponent<Transform>().position;

        if (playerLastPos != playerPos) // If the player has moved since last frame
        {
            Enqueue(playerPos);
            playerLastPos = playerPos;
        }

        anim.SetFloat("Horizontal", npcPos.x - npcLastPos.x);
		anim.SetFloat("Vertical", npcPos.y - npcLastPos.y);

        npcLastPos = npcPos;
    }

    public void Enqueue(Vector3 position)
    {
        playerPositions.Enqueue(position);

        while (playerPositions.Count > size)
        {
            gameObject.GetComponent<Transform>().position = playerPositions.Dequeue(); // Teleport the NPC to the old player's position
        }
    }

}
